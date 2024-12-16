using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Models;

namespace Blazor.BLL.Managers.Abstract
{
    public interface IStockManager : IManager<Stock>
    {
		Task UpdateStockAfterSaleAsync(int id,int quantity);
		Task IncreaseOrUpdateStockAsync(Stock stock,string uppdateOrIncreaseName);

		Task<List<int>> GetStockMovement();
	}
}
