using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
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
