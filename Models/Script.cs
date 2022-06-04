using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.Models
{
    [Table("script")]
    public class Script
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScriptID { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public DateTime ScheduledDate { get; set; }
        [NotMapped]
        public string Group { get; set; }
        [NotMapped]
        public int Events { get; set; }
        [NotMapped]
        public bool Published { get; set; }
        [NotMapped]
        public bool Scheduled { get; set; }
    }
}
