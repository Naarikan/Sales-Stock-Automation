using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.Managers.Abstract;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;

namespace Blazor.BLL.Managers.Concrete
{
	public class StockMovementManager:BaseManager<StockMovement>,IStockMovementManager
	{
		IStockMovementRepository _stockMovementRepository;

		public StockMovementManager(IStockMovementRepository stockMovementRepository) : base(stockMovementRepository)
		{
			_stockMovementRepository = stockMovementRepository;
		}

		public async Task<bool> CheckStockMovement(int stockId)
		{
			return await _stockMovementRepository.CheckStockMovement(stockId);
		}
	}
}
