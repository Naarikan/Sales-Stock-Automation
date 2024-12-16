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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext db) : base(db)
        {
        }

		public async Task ConfirmEmployee(int id)
		{
			var employee=await _db.Set<Employee>().FindAsync(id);
			employee.IsConfirmed = true;
			await _db.SaveChangesAsync();

		}
	}
}
