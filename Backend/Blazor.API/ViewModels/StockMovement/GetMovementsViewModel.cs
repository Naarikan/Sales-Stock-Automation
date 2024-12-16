namespace Blazor.API.ViewModels.StockMovement
{
	public class GetMovementsViewModel
	{
		public int Id { get; set; }
		public int Movement { get; set; }
		public int StockId { get; set; }
		public int Stock {get; set; }
		public string ProductName { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
		
	}
}
