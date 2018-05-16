namespace ProsumerInfo.Models.Interfaces
{
	public interface IProsumer
	{
		int Id { get; set; }
		IWallet Wallet { get; set; }
		string Navn { get; set; }
		ProsumerType Type { get; set; }
		ISmartMeter SmartMeter { get; set; }
	}
}