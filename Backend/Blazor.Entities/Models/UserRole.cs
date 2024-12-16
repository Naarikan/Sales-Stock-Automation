using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
    public class UserRole:BaseEntity
    {
        public int RoleId   { get; set; }
        public int EmployeeId { get; set; }


        public virtual Role Role { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
