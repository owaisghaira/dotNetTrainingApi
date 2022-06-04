using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class RoleHandler
    {
        public static Role Get(int id)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Role.Where(x => x.RoleID == id).FirstOrDefault();
            }
        }

        public static List<Role> GetAll()
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Role.ToList();
            }
        }
    }
}
