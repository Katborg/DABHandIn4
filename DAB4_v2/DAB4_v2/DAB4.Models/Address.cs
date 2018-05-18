using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }

    }
}
