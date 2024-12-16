using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Business.Managers.Abstract;
using Entities.Models;

namespace Business.Managers.Concrete
{
	public class CustomerService:ICustomerService
	{
		private readonly HttpClient _httpClient;

		public CustomerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<CustomerModel>> GetCustomersAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<CustomerModel>>("https://localhost:7146/blazor.api/Customer/getCustomers");
		}

		public async Task<CustomerModel> GetCustomerByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<CustomerModel>($"https://localhost:7146/blazor.api/Customer/customergetbyid/{id}");
		}

		public async Task AddCustomerAsync(CustomerModel Customer)
		{
			var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/Customer/addCustomer", Customer);
			response.EnsureSuccessStatusCode();
		}

		public async Task UpdateCustomerAsync(CustomerModel Customer)
		{
			var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/Customer/updateCustomer/", Customer);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteCustomerAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/Customer/deleteCustomer/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
