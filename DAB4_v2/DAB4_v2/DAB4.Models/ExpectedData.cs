using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
{
    public class ExpectedData
    {
        [Key]
        public int Id { get; set; }

        public int Consumption { get; set; }
        public int Production { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
