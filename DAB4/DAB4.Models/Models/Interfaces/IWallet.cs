namespace DAB4.Models.Models.Interfaces
{
	public interface IWallet
	{
		double Balance { get; }

		double AddToWallet { set; }
	}
}