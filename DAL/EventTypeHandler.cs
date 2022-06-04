using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class EventTypeHandler
    {
        public static string GetType(int eventTypeId)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.EventType.Where(x => x.EventTypeID == eventTypeId).FirstOrDefault().Name;
            }
        }

        public static List<EventType> GetAll()
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.EventType.ToList();
            }
        }
    }
}
