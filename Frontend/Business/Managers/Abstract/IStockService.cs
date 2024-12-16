using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
    public interface IStockService
    {
        Task<List<StockModel>> GetStocksAsync();
        Task<StockModel> GetStockByIdAsync(int id);

        Task AddStockAsync(StockModel Stock);
        Task UpdateStockAsync(StockModel Stock,string name);
        Task DeleteStockAsync(int id);

        Task IncreaseStockAsync(IncreaseStockModel model);
    }
}
