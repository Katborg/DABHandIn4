namespace DAB4.Models.Models.Interfaces
{
	public interface ISmartMeter
	{
		string KobberforbindelseId { get; set; }
		double Production { get; set; }
		double Comsumption { get; set; }
		double Balance { get; }
		int SamrtgridId { get; set; }
	}
}