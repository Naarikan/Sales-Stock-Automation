namespace Blazor.API.ViewModels.Stock
{
    public class StockListModel
    {
        public int Id { get; set; } 
        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }
		public string ProductCategory { get; set; }
		public int ProductId { get; set; }
        public string Product { get; set; }
      
    }
}
