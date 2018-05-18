using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
{
    class Trade
    {
        [Key]
        public int Id { get; set; }

        public int ProducedEnergy { get; set; }
        public int ConsumedEnergy { get; set; }
        public int SumOfEnergy { get; set; }
        public int ProsumerId { get; set; }
  
    }
}
