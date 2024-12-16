using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Entities.Models
{
    public class Account:BaseEntity
    {
        public string PasswordHash { get; set; }


        public int EmployeeId { get; set; }
      

        //Relations
        public Employee Employee { get; set; }


       
    }
}
