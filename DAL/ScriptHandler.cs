using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class ScriptHandler
    {
        public static List<Script> GetAll()
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Script.OrderByDescending(x => x.ScriptID).ToList();
            }
        }

        public static List<Script> GetUpcoming()
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                List<int> ids = ctx.ScriptGroup.Where(x => x.ScheduledDate > DateTime.Now).Select(x => x.ScriptID).ToList();
                return ctx.Script.Where(x => ids.Contains(x.ScriptID)).ToList();
            }
        }

        public static Script GetByID(int scriptId)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Script.Where(x => x.ScriptID == scriptId).FirstOrDefault();
            }
        }

        public static bool Update(Script model)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.Entry(model).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Toggle(int scriptID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ScriptGroup scriptGroup = ctx.ScriptGroup.Where(x => x.ScriptID == scriptID).FirstOrDefault();

                scriptGroup.Status = scriptGroup.Status == 1 ? 0 : 1;

                ctx.Entry(scriptGroup).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Add(Script script)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                ctx.Script.Add(script);
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Delete(int scriptID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                Script script = ctx.Script.Where(x => x.ScriptID == scriptID).FirstOrDefault();
                ctx.Script.Remove(script);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
