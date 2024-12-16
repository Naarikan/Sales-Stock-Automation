using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.DAL.Context;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;

namespace Blazor.DAL.Repositories.Concrete
{
    public class CustomerRepository:BaseRepository<Customer>,ICustomerRepository
    {
        public CustomerRepository(MyContext db):base(db)
        {
            
        }
    }
}
