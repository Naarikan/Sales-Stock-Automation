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
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(MyContext db) : base(db)
        {
			
        }

        public async Task<Sale> GetTopSaledProductAsync()
        {
            var topSale = await _db.Set<Sale>().GroupBy(s => s.ProductId) .Select(tsale => new
                           {
                               ProductId = tsale.Key, 
                               TotalQuantity = tsale.Sum(s => s.SalesQuantity) 
                           }) .OrderByDescending(g => g.TotalQuantity).FirstOrDefaultAsync(); 

            var product = await _db.Set<Product>().FindAsync(topSale.ProductId);
            return new Sale
            {
                Product = product,
                SalesQuantity = topSale.TotalQuantity
            };
        }

        public async Task ProcessSaleASync(Sale entity)
		{
				await _db.AddAsync(entity);
			    
		}
	}
}
