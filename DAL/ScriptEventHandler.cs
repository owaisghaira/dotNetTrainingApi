using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class ScriptEventHandler
    {
        public static List<ScriptEvent> GetByScriptID(int scriptId)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.ScriptEvent.Where(x => x.ScriptID == scriptId).OrderBy(x => x.Duration).ToList();
            }
        }

        public static ScriptEvent Get(int scriptEventId)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.ScriptEvent.Where(x => x.ScriptEventID == scriptEventId).FirstOrDefault();
            }
        }

        public static bool Add(ScriptEvent scriptEvent)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.ScriptEvent.Add(scriptEvent);
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Delete(int scriptEventID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ScriptEvent eventItem = ctx.ScriptEvent.Where(x => x.ScriptEventID == scriptEventID).FirstOrDefault();
                ctx.ScriptEvent.RemoveRange(eventItem);
                ctx.SaveChanges();
                return true;
            }
        }

    }
}
