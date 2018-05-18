using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAB4.Models.Models;

namespace DAB4.Models.Models2
{
    public class SmartGrid
    {
        [Key]
        public int Id { get; set; }

        public int NumberOfPrivateHomes { get; set; }
        public int NumberOfCompanies { get; set; }
        public int EnergyBalance { get; set; }
        public virtual List<SmartMeter> SmartMeters { get; set; }
        public virtual  WireInfo WireInfo { get; set; }
        public virtual EnergyStorage EnergyStorage { get; set; }

        public SmartGrid()
        {
            SmartMeters = new List<SmartMeter>();
        }
    }
}
