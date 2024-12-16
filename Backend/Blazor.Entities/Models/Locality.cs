using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Enums;
using Blazor.Entities.Interfaces;

namespace Blazor.Entities.Models
{
    public class Locality : BaseEntity
    {
      public string Name { get; set; }
      public int ParentId{get ; set; }


       


	}
}
