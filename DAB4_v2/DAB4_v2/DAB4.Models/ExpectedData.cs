using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
{
    class ExpectedData
    {
        [Key]
        public int Id { get; set; }

        public int Consumption { get; set; }
        public int Production { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
