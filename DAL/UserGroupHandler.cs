using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class UserGroupHandler
    {
        public static bool Add(UserGroup userGroup)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.UserGroup.Add(userGroup);
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool DeleteGroup(int groupID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                List<UserGroup> userGroup = ctx.UserGroup.Where(x => x.GroupID == groupID).ToList();
                ctx.UserGroup.RemoveRange(userGroup);
                ctx.SaveChanges();
                return true;
            }
        }

        public static List<int> GetGroupUsers(int groupID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return  ctx.UserGroup.Where(x => x.GroupID == groupID).Select(x => x.UserID).ToList();
            }
        }
    }
}
