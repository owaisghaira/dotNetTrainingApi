using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class EventHandler
    {
        public static List<Event> GetAll()
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Event.OrderByDescending(x => x.EventID).ToList();
            }
        }

        public static Event GetByID(int eventID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Event.Where(x => x.EventID == eventID).FirstOrDefault();
            }
        }

        public static int GetCount(int scriptID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.ScriptEvent.Where(x => x.ScriptID == scriptID).Count();
            }
        }

        public static List<Event> GetByIds(List<int> ids)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Event.Where(x => ids.Contains(x.EventID)).ToList();
            }
        }

        public static List<Event> GetByType(int typeId)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Event.Where(x => x.EventType == typeId).ToList();
            }
        }

        public static bool Add(Event model)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                ctx.Event.Add(model);
                ctx.SaveChanges();
                return true;
            }
        }


        public static bool Update(Event model)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.Entry(model).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Delete(int eventID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                Models.Event eventItem = ctx.Event.Where(x => x.EventID == eventID).FirstOrDefault();
                ctx.Event.RemoveRange(eventItem);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
