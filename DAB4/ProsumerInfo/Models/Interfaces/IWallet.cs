namespace ProsumerInfo.Models.Interfaces
{
	public interface IWallet
	{
		double Balance { get; }

		void AddToWallet(double amount);
	}
}