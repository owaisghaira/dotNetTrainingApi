using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingScheduler.Models
{
    [Table("weather_info")]
    public class WeatherInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeatherInfoID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime RecordDate { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string Humidity { get; set; }
        public string Temprature { get; set; }
        public string Visibility { get; set; }
        public string WindGusts { get; set; }
        public string CloudCover { get; set; }
        public string Location { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string HighTemprature { get; set; }
        public string LowTemprature { get; set; }
        public string Pressure { get; set; }
        public string Desctiption { get; set; }
        public int Amount { get; set; }
        public string FeelsLike { get; set; }
        public int AmountType { get; set; }
        public string UVIndex { get; set; }
    }
}
