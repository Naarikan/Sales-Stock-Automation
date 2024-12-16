using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class SaleModel
	{
		public int Id { get; set; }
		public int SalesQuantity { get; set; }
		public string ProductName { get; set; }
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public decimal TotalAmount { get; set; }
		public string CategoryName { get; set; }
		public int EmployyeId { get; set; }
		public string EmployeeName { get; set; }
		public string CustomerName { get; set; }
		public int CustomerId { get; set; }

		public DateTime SaleTime { get; set; }
	}
}
