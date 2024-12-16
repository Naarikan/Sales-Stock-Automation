using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
	public interface ICustomerService
	{
		Task<List<CustomerModel>> GetCustomersAsync();
		Task<CustomerModel> GetCustomerByIdAsync(int id);

		Task AddCustomerAsync(CustomerModel Customer);
		Task UpdateCustomerAsync(CustomerModel Customer);
		Task DeleteCustomerAsync(int id);
	}
}
