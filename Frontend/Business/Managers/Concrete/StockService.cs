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
    public class StockService : IStockService
    {
        private readonly HttpClient _httpClient;

        public StockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StockModel>> GetStocksAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<StockModel>>("https://localhost:7146/blazor.api/stock/getstocks");
        }

        public async Task<StockModel> GetStockByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StockModel>($"https://localhost:7146/blazor.api/stock/stockgetbyid/{id}");
        }

        public async Task AddStockAsync(StockModel Stock)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/stock/addstock", Stock);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateStockAsync(StockModel Stock,string name)
        {
                Stock.UpdateName = name;
                var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/stock/updatestock/", Stock);
                response.EnsureSuccessStatusCode();
            
        }

        public async Task DeleteStockAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/stock/deletestock/{id}");
            response.EnsureSuccessStatusCode();
        }

		public async Task IncreaseStockAsync(IncreaseStockModel model)
		{
			
			var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/stock/increasestock/", model);
			response.EnsureSuccessStatusCode();
		}
	}
}
