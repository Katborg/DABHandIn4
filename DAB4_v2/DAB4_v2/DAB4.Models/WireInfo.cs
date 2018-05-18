using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
{
    public class WireInfo
    {
        [Key]
        public int Id { get; set; }

        public string Producer { get; set; }
        public string Model { get; set; }
        public int Thickness { get; set; }
        public string DateOfInstallation { get; set; }

    }
}
