using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DAB4.Models
{
    public class SmartGrid
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
