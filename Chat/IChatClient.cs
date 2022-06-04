using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.Chat
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}
