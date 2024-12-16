using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
	public class StockMovementModel
	{
		public int Id { get; set; }
		public int Movement { get; set; }
		public int StockId { get; set; }
		public int Stock { get; set; }
		public string ProductName { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }

	}
}
