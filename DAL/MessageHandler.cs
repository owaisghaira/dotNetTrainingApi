using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Models;

namespace TrainingScheduler.DAL
{
    public class MessageHandler
    {
        public static List<Message> GetAll(int from, int to)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                return ctx.Message.Where(x => (x.From == from && x.To == to) || (x.From == to && x.To == from)).OrderByDescending(x => x.MessageID).ToList();
            }
        }

        public static bool Add(Message Message)
        {
            using (TrainingSchedulerContext ctx = new TrainingSchedulerContext())
            {
                ctx.Message.Add(Message);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
