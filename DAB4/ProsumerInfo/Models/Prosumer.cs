using ProsumerInfo.Models.Interfaces;

namespace ProsumerInfo.Models
{
    class Prosumer : IProsumer
	{
	    public int Id { get; set; }
	    public string Navn { get; set; }
	    public ProsumerType Type { get; set; }
	    public Wallet MyWallet { get; set; }
    }

	enum ProsumerType
	{
		Privat
		,Virksomhed
	}
}
