using ProsumerInfo.Models.Interfaces;

namespace ProsumerInfo.Models
{
    public class Prosumer : IProsumer
	{
		public Prosumer(int id, string navn, ProsumerType type, IWallet wallet, ISmartMeter smartMeter)
		{
			Id = id;
			Navn = navn;
			Type = type;
			Wallet = wallet;
			SmartMeter = smartMeter;

		}
	    public int Id { get; set; }
	    public string Navn { get; set; }
	    public ProsumerType Type { get; set; }
	    public IWallet Wallet { get; set; }
		public ISmartMeter SmartMeter { get; set; }
    }

	public enum ProsumerType
	{
		Privat
		,Virksomhed
	}
}
