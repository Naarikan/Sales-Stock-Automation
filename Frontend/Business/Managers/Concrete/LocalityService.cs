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
    public class LocalityService:ILocalityService
    {
        private readonly HttpClient _httpClient;

        public LocalityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<LocalityModel>> GetLocalitiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LocalityModel>>("https://localhost:7146/blazor.api/Locality/getlocalities");
        }

        public async Task<LocalityModel> GetLocalityByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<LocalityModel>($"https://localhost:7146/blazor.api/Locality/getlocalitybyid/{id}");
        }

        public async Task AddLocalityAsync(LocalityModel Locality)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/Locality/addlocality", Locality);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateLocalityAsync(LocalityModel Locality)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/Locality/updatelocality/", Locality);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteLocalityAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/Locality/deleteLocality/{id}");
            response.EnsureSuccessStatusCode();
        }

		public async Task<List<LocalityModel>> GetSubLocalitiesAsync(int parentId)
		{
			return await _httpClient.GetFromJsonAsync<List<LocalityModel>>($"https://localhost:7146/blazor.api/locality/getbyparent/{parentId}");
		}

		public async Task<LocalityModel> GetSubLocality(int parentid)
		{
			return await _httpClient.GetFromJsonAsync<LocalityModel>($"https://localhost:7146/blazor.api/locality/getlocality/{parentid}");
		}
	}
}
