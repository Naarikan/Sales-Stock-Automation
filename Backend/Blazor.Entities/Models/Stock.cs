using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
    public class Stock:BaseEntity
    {


        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }   

       
        [JsonIgnore]
        public virtual ICollection<StockMovement> StockMovements { get; set; }


    }
}
