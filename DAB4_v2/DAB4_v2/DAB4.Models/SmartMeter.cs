using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
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
