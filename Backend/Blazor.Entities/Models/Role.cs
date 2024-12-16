using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; }


        
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
