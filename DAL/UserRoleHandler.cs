using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class UserRoleHandler
    {
        public static UserRole GetByUserID(int userID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.UserRole.Where(x => x.UserID == userID).FirstOrDefault();
            }
        }

        public static bool Add(UserRole userRole)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                ctx.UserRole.Add(userRole);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
