using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
{
    public class Prosumer
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int TokenBalance { get; set; }
        public Address Address { get; set; }

        public virtual List<SmartMeterData> SmartMeterDatas { get; set; }
        public virtual List<ExpectedData> ExpectedDatas { get; set; }

        public Prosumer()
        {
            SmartMeterDatas = new List<SmartMeterData>();
            ExpectedDatas = new List<ExpectedData>();
        }
    }
}
