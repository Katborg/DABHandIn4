using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAB4.Models
{
    public class TransferWindow
    {
        public TransferWindow()
        {
            Trades = new List<Trade>();
        }
        [Key]
        public int Id { get; set; }
        public int Period { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Price { get; set; }
        public int SmartGridId { get; set; }
        public int SumOfTrades { get; set; }
        public virtual List<Trade> Trades { get; set ; }

    }
}
