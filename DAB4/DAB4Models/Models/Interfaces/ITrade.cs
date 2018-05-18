namespace TrandeInfo.Models
{
	interface ITrade
	{
		double AmountKWH { get; set; }
		int Id { get; set; }
		double price { get; set; }
		int ProsumerId { get; set; }
		int SmartGridId { get; set; }
	}
}