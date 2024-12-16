using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
       


        //Relations
        public virtual ICollection<Product> Products { get; set; }
    }
}
