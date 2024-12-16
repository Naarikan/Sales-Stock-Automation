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
	public class StockMovementService : IStockMovementService
	{
		private readonly HttpClient _httpClient;

		public StockMovementService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<StockMovementModel>> GetMovementsAsync()
		{
			return await _httpClient.GetFromJsonAsync<List<StockMovementModel>>("https://localhost:7146/blazor.api/stockmovement/getmovements");
		}

        
    }
}
