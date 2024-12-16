using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
	public interface ISaleService
	{
		Task<List<SaleModel>> GetSalesAsync();
		Task<SaleModel> GetSaleByIdAsync(int id);

		Task AddSaleAsync(SaleModel Sale);
		Task UpdateSaleAsync(SaleModel Sale);
		Task DeleteSaleAsync(int id);
	}
}
