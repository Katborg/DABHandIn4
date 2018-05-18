using DAB4.Models.Models.Interfaces;

namespace DAB4.Models.Models
{
	public class Wallet : IWallet
	{
		private double _balance;

		public double Balance
		{
			get
			{
				return _balance;
			}
		}

		public double AddToWallet
		{
			set
			{
				_balance += value;
			} 
		}
	}
}