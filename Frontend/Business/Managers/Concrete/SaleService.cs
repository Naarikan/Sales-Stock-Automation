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
	public class SaleService:ISaleService
	{
		private readonly HttpClient _httpClient;

		public SaleService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<SaleModel>> GetSalesAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<SaleModel>>("https://localhost:7146/blazor.api/sale/getsales");
		}

		public async Task<SaleModel> GetSaleByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<SaleModel>($"https://localhost:7146/blazor.api/sale/salegetbyid/{id}");
		}

		public async Task AddSaleAsync(SaleModel Sale)
		{
			var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/sale/addsale", Sale);
			response.EnsureSuccessStatusCode();
		}

		public async Task UpdateSaleAsync(SaleModel Sale)
		{
			var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/sale/updatesale/", Sale);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteSaleAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/Sale/deletesale/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
