﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        

        public int CategoryId { get; set; }

        //Relations
        
        public virtual Category Category { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
