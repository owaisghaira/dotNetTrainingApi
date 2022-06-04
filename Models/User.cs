using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Locale { get; set; }
        public string Password { get; set; }
        public string StationID { get; set; }
        public bool IsReady { get; set; }
        [NotMapped]
        public string Role { get; set; }
        [NotMapped]
        public int RoleID { get; set; }
    }
}
