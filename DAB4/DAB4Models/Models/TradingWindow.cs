using ProsumerInfo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrandeInfo.Models
{
    public class TradingWindow : ITradingWindow
	{
	    private List<Trade> _trades;
	    private int _smarGridId;
	    private DateTime _startDateTime;
	    private bool _openBool;
		private string _smartgridId;


		public TradingWindow(string SmartgridId ,double kwhPrice, DateTime startDateTime)
	    {
		    KWHPrice = kwhPrice;
		    _startDateTime = startDateTime;
		    _smartgridId = SmartgridId;
			_trades = new List<Trade>();
		    _openBool = true;
		}
		public double KWHPrice { get; private set; }
	    public double Sell(double amountKWH, IProsumer custumer)
	    {
		    double price = 0;

			if (_openBool)
		    {
			    price = (amountKWH * KWHPrice);
				_trades.Add(new Trade(custumer.Id, _smarGridId, amountKWH, price));
			    custumer.SmartMeter.Production -= amountKWH;
		    }

			return price;
	    }
	    public double Buy(double amountKWH, IProsumer custumer)
	    {
			double price = 0;

		    if (_openBool)
		    {
			    price = -(amountKWH * KWHPrice);
				_trades.Add(new Trade(custumer.Id, _smarGridId, amountKWH, price));
			    custumer.SmartMeter.Production += amountKWH;
			}

		    return price;
		}
	    public void CloseWindow(DateTime endTime)
	    {
		    if (_openBool)
		    {
			    double KWHSum = 0;
			    double MoneySum = 0;

			    foreach (var trade in _trades)
			    {
				    KWHSum += trade.AmountKWH;
				    MoneySum += trade.price;
			    }

			    _openBool = false;
		    }

	    }
	}
}
