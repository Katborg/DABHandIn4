using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
{
    class EnergyStorage
    {
        [Key]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int EnergyAmount { get; set; }
    }
}
