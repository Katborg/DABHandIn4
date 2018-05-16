using System;
using System.Collections.Generic;
using System.Text;

namespace TrandeInfo.Models
{
    class Trade : ITrade
	{
	    public int Id { get; set; }
	    public int ProsumerId { get; set; }
	    public int SmartGridId { get; set; }
	    public double AmountKWH { get; set; }
	    public double price { get; set; }

		public Trade(int prosumerId, int smartGridId, double amountKwh, double price)
		{
			ProsumerId = prosumerId;
			SmartGridId = smartGridId;
			AmountKWH = amountKwh;
			this.price = price;
		}

    }
}
