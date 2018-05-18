using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAB4.Models.Models2
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
