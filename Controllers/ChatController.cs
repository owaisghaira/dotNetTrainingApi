using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.Chat;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;

namespace TrainingScheduler.Controllers
{
    public class ChatController: Controller
    {
        public JsonResult Index(int from,int to)
        {
            List<Message> messages = MessageHandler.GetAll(from,to);

            List<ChatMessage> userMessages = new List<ChatMessage>();

            messages.ForEach(x =>
            {
                ChatMessage msg = new ChatMessage()
                {
                    From = x.From,
                    To = x.To,
                    MessageText = x.MessageText,
                    MessageTime = x.MessageTime
                };

                userMessages.Add(msg);
            });

            return Json(new { Success = true, Payload = userMessages });
        }
    }
}
