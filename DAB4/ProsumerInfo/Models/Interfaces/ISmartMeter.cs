namespace ProsumerInfo.Models.Interfaces
{
	interface ISmartMeter
	{
		string kobberforbindelseId { get; set; }
		double Production { get; set; }
		double Comsumption { get; set; }
		int SamrtgridId { get; set; }
	}
}