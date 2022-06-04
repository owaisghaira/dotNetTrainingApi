using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("user_station")]
    public class UserStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserStationID { get; set; }
        public int UserID { get; set; }
        public int StationID { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
