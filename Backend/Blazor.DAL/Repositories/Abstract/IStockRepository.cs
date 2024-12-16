using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Models;

namespace Blazor.DAL.Repositories.Abstract
{
    public interface IStockRepository:IRepository<Stock>
    {
		//Task UpdateStockAfterSaleAsync(int productId, int quantitySold);

	}
}
