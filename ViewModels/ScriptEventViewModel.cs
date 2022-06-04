using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.ViewModels
{
    public class ScriptEventViewModel
    {
        public int ScriptEventID { get; set; }
        public int EventID { get; set; }
        public int ScriptID { get; set; }
        public string Time { get; set; }
        public string Parameters { get; set; }
        public string Type { get; set; }
        public string FileData { get; set; }
        public int EventTypeID {get;set;}
        public string Link {get;set;}

    }
}
