using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.Managers.Abstract;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;

namespace Blazor.BLL.Managers.Concrete
{
    public class CustomerManager:BaseManager<Customer>,ICustomerManager
    {
        ICustomerRepository _icr;
        public CustomerManager(ICustomerRepository icr) :base(icr) 
        {
            _icr = icr;
        }
    }
}
