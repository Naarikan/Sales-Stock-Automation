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
    public class StockManager:BaseManager<Stock>,IStockManager
    {
        IStockRepository _ısr;
		ISaleRepository _ısaler;
		IStockMovementManager _ismr;
        public StockManager(IStockRepository ısr, ISaleRepository ısale,IStockMovementManager stockMovementRepository) :base(ısr)
        {
            _ısr=ısr;
			_ısaler = ısale;
			_ismr = stockMovementRepository;
        }

		public Task<List<int>> GetStockMovement()
		{
			throw new NotImplementedException();
		}

		public async Task IncreaseOrUpdateStockAsync(Stock _stock, string uppdateOrIncreaseName)
		{
			var stock = await _ısr.GetByIdAsync(_stock.Id);

			if (uppdateOrIncreaseName=="AddStock")
			{
				stock.Quantity += _stock.Quantity;
				await _ısr.UpdateAsync(stock);

				if (await _ismr.CheckStockMovement(stock.Id))
				{
					var stockMovement = await _ismr.FilterFirstOrDefaultAsync(sm => sm.StockId == stock.Id);
					stockMovement.Movement += _stock.Quantity;
					await _ismr.UpdateAsync(stockMovement);
				}
				else
				{
					StockMovement stockMovement = new StockMovement()
					{
						StockId = stock.Id,
						Movement = _stock.Quantity
						
					};

					await _ismr.AddASync(stockMovement);
				}

			}
			else if(uppdateOrIncreaseName=="UpdateStock") { 
			     
			     await UpdateAsync(_stock);
			    }

		}

		public async Task UpdateStockAfterSaleAsync(int id, int quantity)
		{
			var stock = await _ısr.FilterFirstOrDefaultAsync(s => s.ProductId == id);
			if (stock != null)
			{
				stock.Quantity -= quantity;
				if (stock.Quantity < 0)
				{
					throw new InvalidOperationException("Stok miktarı yetersiz.");
				}

				if (await _ismr.CheckStockMovement(stock.Id))
				{
					var stockMovement = await _ismr.FilterFirstOrDefaultAsync(sm => sm.StockId == stock.Id);
					stockMovement.Movement -= quantity;
					await _ismr.UpdateAsync(stockMovement);

				}
				else
				{
					StockMovement stockMovement = new StockMovement()
					{
						StockId=stock.Id,
						Movement =-quantity,
						

					};
					await _ismr.AddASync(stockMovement);
				}

				await _ısr.UpdateAsync(stock);
				
			}
			else
			{
				throw new InvalidOperationException("Stok bulunamadı.");
			}
		
		}

		
	}
}
