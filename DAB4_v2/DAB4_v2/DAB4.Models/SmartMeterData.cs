using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
{
    public class SmartMeterData
    {
        [Key]
        public int Id { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Produced { get; set; }
        public int Consumed { get; set; }

    }
}
