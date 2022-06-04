using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.Models
{
    [Table("script_event")]
    public class ScriptEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScriptEventID { get; set; }
        public int ScriptID { get; set; }
        public int EventID { get; set; }
        public TimeSpan Duration { get; set; }
        public string Parameters { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }

}
