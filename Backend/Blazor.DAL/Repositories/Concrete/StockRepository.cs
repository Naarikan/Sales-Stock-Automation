using Blazor.DAL.Context;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Repositories.Concrete
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {

        public StockRepository(MyContext db) : base(db)
        {
        }

		//public async Task UpdateStockAfterSaleAsync(int productId, int quantitySold)
		//{
		//	var stock= await _db.Stocks.FirstOrDefaultAsync(s => s.ProductId == productId);
		//	if (stock != null)
		//	{
		//		stock.Quantity -= quantitySold;

				
		//		if (stock.Quantity < 0)
		//		{
		//			throw new InvalidOperationException("Stok miktarı yetersiz.");
		//		}

				
		//		_db.Stocks.Update(stock);
		//		await _db.SaveChangesAsync();
		//	}
		//	else
		//	{
		//		throw new InvalidOperationException("Stok bulunamadı.");
		//	}

		//}
	}
}
