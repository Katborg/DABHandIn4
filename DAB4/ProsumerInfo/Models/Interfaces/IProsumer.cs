namespace ProsumerInfo.Models.Interfaces
{
	interface IProsumer
	{
		int Id { get; set; }
		Wallet MyWallet { get; set; }
		string Navn { get; set; }
		ProsumerType Type { get; set; }
	}
}