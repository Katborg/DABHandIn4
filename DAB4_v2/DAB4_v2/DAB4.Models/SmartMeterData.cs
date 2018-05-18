using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
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
