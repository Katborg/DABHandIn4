using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
{
    class Address
    {
        [Key]
        public int Id { get; set; }

        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }

    }
}
