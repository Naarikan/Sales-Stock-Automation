using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Blazor.Entities.Enums;
using Blazor.Entities.Interfaces;

namespace Blazor.Entities.Models
{
	public class StockMovement :BaseEntity
	{
		public int Movement { get; set; }
	
		public int StockId { get; set; }

		[JsonIgnore]
		public virtual Stock Stock { get; set; }

	}
}
