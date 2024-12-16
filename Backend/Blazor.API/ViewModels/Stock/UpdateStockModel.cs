namespace Blazor.API.ViewModels.Stock
{
    public class UpdateStockModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
		public string UpdateName { get; set; }

	}
}
