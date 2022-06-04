using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;
using TrainingScheduler.ViewModels;

namespace TrainingScheduler.Controllers
{
    public class ScriptController : Controller
    {
        public JsonResult Index()
        {
            List<Script> scripts = ScriptHandler.GetAll();

            scripts.ForEach(x =>
            {
                x.Events = DAL.EventHandler.GetCount(x.ScriptID);

                ScriptGroup scriptGroup = ScriptGroupHandler.Get(x.ScriptID);

                if (scriptGroup != null)
                {
                    x.Published = scriptGroup.Status == 1;
                    x.ScheduledDate = scriptGroup.ScheduledDate;
                    x.Scheduled = scriptGroup.ScheduledDate != null;
                }
                else
                {
                    x.Published = false;
                    x.Scheduled = false;
                }
            });

            return Json(new { Success = true, Payload = scripts });
        }

        public JsonResult Scheduled()
        {
            List<Script> scripts = ScriptHandler.GetUpcoming();

            scripts.ForEach(x =>
            {
                ScriptGroup scriptGroup = ScriptGroupHandler.Get(x.ScriptID);
                x.ScheduledDate = scriptGroup.ScheduledDate;
                x.Group = GroupHandler.GetName(scriptGroup.GroupID);
            });

            return Json(new { Success = true, Payload = scripts });
        }

        [HttpPost]
        public JsonResult ScheduledScript([FromBody] ScriptGroupViewModel model)
        {
            ScriptGroup scriptGroup = new ScriptGroup()
            {
                GroupID = model.GroupID,
                ScheduledDate = model.ScheduledDate,
                ScriptID = Convert.ToInt32(model.ScriptID)
            };

            ScriptGroupHandler.Add(scriptGroup);
            
            return Json(new { Success = true });
        }

        public JsonResult Publish(int scriptID)
        {
            ScriptGroupHandler.Publish(scriptID);
            return Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult Duplicate([FromBody] DuplicateScriptViewModel model)
        {
            int scriptID = Convert.ToInt32(model.ScriptID);
            Script oldScript = ScriptHandler.GetByID(scriptID);
            List<ScriptEvent> events = ScriptEventHandler.GetByScriptID(scriptID);

            Script script = new Script()
            {
                 Name = model.Name
            };

            ScriptHandler.Add(script);

            events.ForEach(x =>
            {
                ScriptEvent scriptEvent = new ScriptEvent()
                {
                    ScriptID = script.ScriptID,
                    EventID = x.EventID,
                    Duration = x.Duration,
                    Parameters = x.Parameters,
                    From = x.From,
                    To = x.To
                };

                ScriptEventHandler.Add(scriptEvent);
            });

            return Json(new { Success = true });
        }

        public JsonResult Get(int id)
        {
            Script script = ScriptHandler.GetByID(id);

            List<ScriptEvent> scriptEvents = ScriptEventHandler.GetByScriptID(script.ScriptID);

            List<Event> events = DAL.EventHandler.GetByIds(scriptEvents.Select(x => x.ScriptID).ToList());

            List<ScriptEventViewModel> scriptEventViewModels = new List<ScriptEventViewModel>();

            scriptEvents.ForEach(x =>
            {
                Models.Event eventItem = DAL.EventHandler.GetByID(x.EventID);

                ScriptEventViewModel model = new ScriptEventViewModel()
                {
                    EventID = x.EventID,
                    ScriptID = x.ScriptID,
                    Type = EventTypeHandler.GetType(eventItem.EventType),
                    FileData = eventItem.FileData,
                    Parameters = x.Parameters,
                    Time = x.Duration.ToString(),
                    ScriptEventID = x.ScriptEventID,
                    EventTypeID = eventItem.EventType,
                    Link = eventItem.Link
                };

                scriptEventViewModels.Add(model);
            });

            return Json(new { Success = true, Payload = new { Script = script, Events = scriptEventViewModels } });
        }

        public JsonResult Save([FromBody] Script model)
        {
            if (ModelState.IsValid)
            {
                if (model.ScriptID > 0)
                {
                    ScriptHandler.Update(model);
                }
                else
                {
                    ScriptHandler.Add(model);
                }

                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }

        public JsonResult Toggle(int scriptID)
        {
            ScriptHandler.Toggle(scriptID);
            
            return Json(new { Success = true });
        }

        [HttpPost]
        public JsonResult SaveEvent([FromBody] ScriptEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                ScriptEvent scriptEvent = new ScriptEvent()
                {
                    Duration = DateTime.Parse(model.Time).TimeOfDay,
                    EventID = model.EventID,
                    ScriptID = model.ScriptID,
                    Parameters = model.Parameters
                };

                ScriptEventHandler.Add(scriptEvent);

                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }

        public JsonResult GetScriptEvent(int scriptEventID)
        {
            ScriptEvent scriptEvent = ScriptEventHandler.Get(scriptEventID);

            return Json(new { Success = true, Payload = scriptEvent });
        }

        public JsonResult Delete(int scriptID)
        {
            ScriptHandler.Delete(scriptID);

            return Json(new { Success = true });
        }

        public JsonResult DeleteScriptEvent(int scriptEventID)
        {
            ScriptEventHandler.Delete(scriptEventID);

            return Json(new { Success = true });
        }

        public JsonResult Preview(int scriptEventID)
        {
            ScriptEvent scriptEvent = ScriptEventHandler.Get(scriptEventID);

            Event eventItem = DAL.EventHandler.GetByID(scriptEvent.EventID);  

            return Json(new { Success = true, Payload = scriptEvent  });
        }
    }
}
