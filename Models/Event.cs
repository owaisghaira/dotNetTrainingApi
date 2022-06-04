using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingScheduler.Models
{
    [Table("event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        public string FileData { get; set; }
        public string Target { get; set; }
        public string Link { get; set; }
        public int EventType { get; set; }

        [NotMapped]
        public string EventTypeDescription { get; set; }
    }
}
