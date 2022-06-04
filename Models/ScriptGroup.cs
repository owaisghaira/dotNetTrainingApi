using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("script_group")]
    public class ScriptGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScriptGroupID { get; set; }
        public int ScriptID { get; set; }
        public int GroupID { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int Status { get; set; }
    }
}
