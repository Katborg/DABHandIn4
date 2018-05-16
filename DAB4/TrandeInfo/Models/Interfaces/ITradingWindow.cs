using System;
using ProsumerInfo.Models.Interfaces;

namespace TrandeInfo.Models
{
	public interface ITradingWindow
	{
		double KWHPrice { get; }

		double Buy(double amountKWH, IProsumer custumer);
		void CloseWindow(DateTime endTime);
		double Sell(double amountKWH, IProsumer custumer);
	}
}