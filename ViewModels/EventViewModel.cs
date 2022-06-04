using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.ViewModels
{
    public class EventViewModel
    {
        public int EventID { get; set; }
        public int EventTypeID { get; set; }
        public string FileData { get; set; }
        public string Target { get; set; }
        public string Link { get; set; }
    }
}
