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
    public class StatisticService:IStatisticService
    {
        private readonly HttpClient _httpClient;

        public StatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StatisticProductModel> GetTopSalesProductAsync()
        {
            return await _httpClient.GetFromJsonAsync<StatisticProductModel>("https://localhost:7146/blazor.api/statistic/gettopsale");
        }

        public async Task<Decimal> GetTotalEarnAsync()
        {
            return await _httpClient.GetFromJsonAsync<Decimal>("https://localhost:7146/blazor.api/statistic/gettotalearn");
        }

        public async Task<List<GetTopCategoriesModel>> GetTopCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GetTopCategoriesModel>>("https://localhost:7146/blazor.api/statistic/gettopcategories");
        }
    }
}
