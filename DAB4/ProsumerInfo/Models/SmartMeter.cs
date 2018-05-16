using ProsumerInfo.Models.Interfaces;

namespace ProsumerInfo.Models
{
	public class SmartMeter : ISmartMeter
	{
		public SmartMeter(string kobberforbindelseId, int samrtgridId)
		{
			this.KobberforbindelseId = kobberforbindelseId;
			Production = 0;
			Comsumption = 0;
			SamrtgridId = samrtgridId;
		}
		public string KobberforbindelseId { get; set; }
		public double Production { get; set; }
		public double Comsumption { get; set; }
		public double Balance => Production - Comsumption;
		public int SamrtgridId { get; set; }

	}
}