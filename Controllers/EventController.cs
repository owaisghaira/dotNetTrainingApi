using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;
using TrainingScheduler.ViewModels;

namespace TrainingScheduler.Controllers
{
    public class EventController : Controller
    {
        public JsonResult Index()
        {
            List<Event> events = DAL.EventHandler.GetAll();

            events.ForEach(x =>
            {
                x.EventTypeDescription = EventTypeHandler.GetType(x.EventType);
            });

            return Json(new { Success = true, Payload = events });
        }

        public JsonResult Get(int eventID)
        {
            Event eventItem = DAL.EventHandler.GetByID(eventID);

            EventViewModel model = new EventViewModel()
            {
                EventID = eventItem.EventID,
                EventTypeID = eventItem.EventType,
                FileData = eventItem.FileData,
                Target = eventItem.Target
            };

            return Json(new { Success = true, Payload = model });
        }

        public JsonResult GetEvents(int typeId)
        {
            List<Event> events = DAL.EventHandler.GetByType(typeId);

            return Json(new { Success = true, Payload = events });
        }

        [HttpPost]
        public JsonResult Save([FromBody] EventViewModel model)
        {
            if (ModelState.IsValid)
            {

                Event eventItem = new Event()
                {
                    EventType = model.EventTypeID,
                    FileData = model.FileData,
                    Target = model.Target,
                    Link = model.Link
                };

                if (model.EventID > 0)
                {
                    eventItem.EventID = model.EventID;
                    DAL.EventHandler.Update(eventItem);
                }
                else
                {
                    DAL.EventHandler.Add(eventItem);
                }

                return Json(new { Success = true });
            }
            else
            {
                return Json(new { Success = false });
            }
        }

        public JsonResult Delete(int id)
        {
            DAL.EventHandler.Delete(id);
            return Json(new { Success = true });
        }
    }
}
