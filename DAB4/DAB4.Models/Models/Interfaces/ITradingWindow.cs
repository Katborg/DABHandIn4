using System;

namespace DAB4.Models.Models.Interfaces
{
	public interface ITradingWindow
	{
		double KWHPrice { get; }

		double Buy(double amountKWH, IProsumer custumer);
		void CloseWindow(DateTime endTime);
		double Sell(double amountKWH, IProsumer custumer);
	}
}