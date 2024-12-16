using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Business.Managers.Abstract;
using Business.Methods.LoginMethods.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace Business.Managers.Concrete
{
	public class EmployeeService : IEmployeeService
	{
		private readonly HttpClient _httpClient;
		private readonly IStorageMethods _storageMethods;

		public EmployeeService(HttpClient httpClient,IStorageMethods storageMethods)
        {
			_httpClient = httpClient;
			_storageMethods = storageMethods;
			
        }

     
      
        public async Task<List<EmployeeModel>> GetEmployeesAsync()
			
		{
			
			return await _httpClient.GetFromJsonAsync<List<EmployeeModel>>("https://localhost:7146/blazor.api/employee/getemployees");
		}

		public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
		{

			return await _httpClient.GetFromJsonAsync<EmployeeModel>($"https://localhost:7146/blazor.api/employee/getemployee/{id}");
		}

		

		public async Task UpdateEmployeeAsync(EmployeeModel Employee)
		{
           
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/employee/updateemployee/", Employee);
			response.EnsureSuccessStatusCode();
		}

		public async Task DestroyEmployeeAsync(int id)
		{
           
            var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/employee/rejectordestroy/{id}");
			response.EnsureSuccessStatusCode();
		}

		public async Task ConfirmEmployeeAsync(int id)
		{
           
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/employee/confirm", id);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteEmployeeAsync(int id)
		{
            
            var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/employee/delete/{id}");
			response.EnsureSuccessStatusCode();
		}

		public async Task UpdateStatAsync(EmployeeModel model)
		{
            
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/employee/updatestat", model);
			response.EnsureSuccessStatusCode();
		}
	}
}
