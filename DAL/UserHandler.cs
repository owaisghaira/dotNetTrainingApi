using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class UserHandler
    {
        public static List<User> GetAll()
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                return ctx.User.ToList();
            }
        }

        public static User Get(User user)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                return ctx.User.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            }
        }

        public static User GetByID(int id)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                return ctx.User.Where(x => x.UserID == id).FirstOrDefault();
            }
        }

        public static bool Add(User user)
        {
            using (var ctx = new TrainingSchedulerContext())
            {
                ctx.User.Add(user);
                ctx.SaveChanges();
                return true;
            }
        }


        public static bool Update(User model)
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
                User user = ctx.User.Where(x => x.UserID == id).FirstOrDefault();
                ctx.User.Remove(user);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
