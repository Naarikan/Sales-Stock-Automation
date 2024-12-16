using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
        public class Sale:BaseEntity
    {

        public int SalesQuantity { get; set; }

        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

		
       
		public virtual Employee Employee { get; set; }
       
        public virtual Customer Customer { get; set; }
       
        public virtual Product Product { get; set; }
		



	}
}
