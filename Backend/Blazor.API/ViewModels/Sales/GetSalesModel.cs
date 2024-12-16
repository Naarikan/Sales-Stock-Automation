namespace Blazor.API.ViewModels.Sales
{
	public class GetSalesModel
	{
		public int Id { get; set; }
		public int SalesQuantity { get; set; }
		public string ProductName { get; set; }
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public decimal TotalAmount { get; set; }
		public string CategoryName { get; set; }
		public int EmployyeId { get; set; }
		public string EmployeeName { get; set; }
		public DateTime SaleTime { get; set; }
	}
}
