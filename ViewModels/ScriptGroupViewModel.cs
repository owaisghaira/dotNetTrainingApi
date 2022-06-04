using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.ViewModels
{
    public class ScriptGroupViewModel
    {
        public string ScriptID { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int GroupID { get; set; }
    }
}
