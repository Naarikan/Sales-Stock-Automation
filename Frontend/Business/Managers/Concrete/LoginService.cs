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
	public class LoginService : ILoginService
	{
		private readonly HttpClient _httpClient;

		public LoginService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public async Task<LoginResponseModel> LoginAsync(LoginRequestModel model)
		{
			var response = await _httpClient.PostAsJsonAsync<LoginRequestModel>("https://localhost:7146/blazor.api/login/loginemployee", model);
			return await response.Content.ReadFromJsonAsync<LoginResponseModel>();
		}

	
	}
}
