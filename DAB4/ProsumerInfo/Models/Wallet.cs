using ProsumerInfo.Models.Interfaces;

namespace ProsumerInfo.Models
{
	public class Wallet : IWallet
	{
		public double Balance { get; private set; }

		public void AddToWallet( double amount)
		{
			Balance += amount;
		}
		
	}
}