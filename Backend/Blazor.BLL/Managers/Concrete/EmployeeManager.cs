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
    public class EmployeeManager:BaseManager<Employee>,IEmployeeManager
    {
        IEmployeeRepository _ıer;
        public EmployeeManager(IEmployeeRepository ıer):base(ıer)
        {
            _ıer=ıer;
        }

		public async Task ConfirmEmployee(int id)
		{
			await _ıer.ConfirmEmployee(id);
		}
	}
}
