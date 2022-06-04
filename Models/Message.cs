using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("message")]
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public int MessageTypeID { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public TimeSpan MessageTime { get; set; }
        public bool Sent { get; set; }
        public bool Read { get; set; }
    }
}
