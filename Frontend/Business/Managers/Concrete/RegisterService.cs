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
    public class RegisterService:IRegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Register(RegisterModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/register/register", model);
            response.EnsureSuccessStatusCode();
        }
    }
}
