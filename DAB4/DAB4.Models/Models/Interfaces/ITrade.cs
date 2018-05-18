namespace DAB4.Models.Models.Interfaces
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