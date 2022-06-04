using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("sail_plan_location")]
    public class SailPlanLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SailPlanLocationID { get; set; }
        public int SailPlanID { get; set; }
        public int SortOrder { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime ExpectedArrival { get; set; }
        public DateTime ExpectedDeparture { get; set; }
        public bool Arrived { get; set; }
    }
}
