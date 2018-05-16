namespace ProsumerInfo.Models.Interfaces
{
	public interface IWallet
	{
		double Balance { get; }

		double AddToWallet { set; }
	}
}