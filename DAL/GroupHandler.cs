using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class GroupHandler
    {
        public static List<Group> GetAll()
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Group.ToList();
            }
        }

        public static Group GetByID(int id)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Group.Where(x => x.GroupID == id).FirstOrDefault();
            }
        }

        public static string GetName(int groupID)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Group.Where(x => x.GroupID == groupID).FirstOrDefault().Name;
            }
        }

        public static bool Add(Group group)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.Group.Add(group);
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Update(Group model)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.Entry(model).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool Delete(int id)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                Group Group = ctx.Group.Where(x => x.GroupID == id).FirstOrDefault();
                ctx.Group.Remove(Group);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
