using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
{
    class SmartMeter
    {
        [Key]
        public int Id { get; set; }

        public string Model { get; set; }
        public string DateOfInstallation { get; set; }
        public Address Address { get; set; }    


    }
}
