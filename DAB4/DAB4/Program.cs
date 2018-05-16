using System;
using ProsumerInfo.Models.Interfaces;
using ProsumerInfo.Models;

using TrandeInfo.Models;

namespace DAB4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DAB Handin4");

	        IWallet id1Wallet = new Wallet();
			ISmartMeter id1SmartMeter = new SmartMeter("1",1);
			IProsumer id1Prosumer = new Prosumer(1,"NumberOne",ProsumerType.Privat, id1Wallet, id1SmartMeter);

	        IWallet id2Wallet = new Wallet();
	        ISmartMeter id2SmartMeter = new SmartMeter("1", 2);
			IProsumer id2Prosumer = new Prosumer(1, "NumberTwo", ProsumerType.Privat, id2Wallet, id2SmartMeter);

			ITradingWindow Window = new TradingWindow("1",2,DateTime.Now);

	        id1Prosumer.SmartMeter.Comsumption = 4;
	        id1Prosumer.SmartMeter.Production = 3;

	        id2Prosumer.SmartMeter.Comsumption = 4;
	        id2Prosumer.SmartMeter.Production = 5;

			id1Prosumer.Wallet.AddToWallet = Window.Buy(-id1Prosumer.SmartMeter.Balance, id1Prosumer);
	        id2Prosumer.Wallet.AddToWallet = Window.Sell(id2Prosumer.SmartMeter.Balance, id2Prosumer);

			Window.CloseWindow(DateTime.Now);

	        Console.WriteLine($"id1Wallet.Balance: {id1Wallet.Balance}");
	        Console.WriteLine($"id1Prosumer.SmartMeter.Balance: {id1Prosumer.SmartMeter.Balance}");

	        Console.WriteLine($"id2Wallet.Balance: {id2Wallet.Balance}");
	        Console.WriteLine($"id2Prosumer.SmartMeter.Balance: {id2Prosumer.SmartMeter.Balance}");

	        Console.Read();
        }
	}
}
