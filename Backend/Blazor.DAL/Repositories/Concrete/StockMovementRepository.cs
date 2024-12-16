using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.DAL.Context;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Repositories.Concrete
{
	public class StockMovementRepository:BaseRepository<StockMovement>,IStockMovementRepository
	{
        public StockMovementRepository(MyContext db):base(db)
        {
            
        }

		public async Task<bool> CheckStockMovement(int stockId)
		{
			return await _db.Set<StockMovement>().AnyAsync(sm=>sm.StockId==stockId);
		}
	}
}
