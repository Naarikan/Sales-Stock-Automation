using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
	public interface IEmployeeService
	{
		Task<List<EmployeeModel>> GetEmployeesAsync();
		Task<EmployeeModel> GetEmployeeByIdAsync(int id);
		Task UpdateEmployeeAsync(EmployeeModel Employee);
		Task DeleteEmployeeAsync(int id);
		Task DestroyEmployeeAsync(int id);

		Task UpdateStatAsync(EmployeeModel model);

		Task ConfirmEmployeeAsync(int id);
	}
}
