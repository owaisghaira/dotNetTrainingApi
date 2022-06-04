using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingScheduler.DAL;
using TrainingScheduler.Models;

namespace TrainingScheduler.Chat
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            Message userMessage = new Message()
            {
                From = message.From,
                To = message.To,
                MessageTime = message.MessageTime,
                MessageText = message.MessageText,
            };
            
            MessageHandler.Add(userMessage);

            await Clients.All.ReceiveMessage(message);
        }
    }
}
