using ProsumerInfo.Models.Interfaces;

namespace ProsumerInfo.Models
{
	class SmartMeter : ISmartMeter
	{
		public string kobberforbindelseId { get; set; }

		public double Production { get; set; }

		public double Usage { get; set; }

		public int SamrtgridId { get; set; }

	}
}