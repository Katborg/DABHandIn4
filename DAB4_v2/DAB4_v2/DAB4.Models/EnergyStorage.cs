using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
{
    public class EnergyStorage
    {
        [Key]
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int EnergyAmount { get; set; }
    }
}
