using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("sail_plan")]
    public class SailPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SailPlanID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Arrived { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime ExpectedArrivalTime { get; set; }
        public string VesselName { get; set; }
        public string OwnerName { get; set; }
        public string TelephoneAddress { get; set; }
        public string MMSINumber { get; set; }
        public bool IsMotor { get; set; }
        public string SizeAndType { get; set; }
        public string ColorOfCabin { get; set; }
        public string ColorOfHulk { get; set; }
        public string ColorOfDeck { get; set; }
        public string OtherCharactistics { get; set; }
        public int NumberOfLifeRafts { get; set; }
        public string DescriptionAndColor { get; set; }
        public bool InboardOrOutboard { get; set; }
        public string HorsePower { get; set; }
        public string Type { get; set; }
        public string VHFRadioMonitorsCH { get; set; }
        public string MFRadioMonitorsFrequency { get; set; }
        public string CBRadioMonitorsCH { get; set; }
    }
}
