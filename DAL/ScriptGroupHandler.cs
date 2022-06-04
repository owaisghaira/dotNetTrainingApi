using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class ScriptGroupHandler
    {
        public static ScriptGroup Get(int scriptID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.ScriptGroup.Where(x => x.ScriptID == scriptID).FirstOrDefault();
            }
        }

        public static bool Add(ScriptGroup model)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                ctx.ScriptGroup.Add(model);
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Publish(int scriptID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ScriptGroup model = ctx.ScriptGroup.Where(x => x.ScriptID == scriptID).FirstOrDefault();
                model.Status = 1;
                ctx.Entry(model).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
