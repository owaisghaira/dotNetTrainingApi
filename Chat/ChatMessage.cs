using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.Chat
{
    public class ChatMessage
    {
        public TimeSpan MessageTime { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string MessageText { get; set; }
    }
}