using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.ComplexModels;
using Blazor.BLL.Managers.Abstract;
using Blazor.DAL.Repositories.Abstract;
using Blazor.DAL.Repositories.Concrete;
using Blazor.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.BLL.Managers.Concrete
{
    public class SaleManager:BaseManager<Sale>,ISaleManager
    {
		private readonly ISaleRepository _saleRepository;
		private readonly IStockManager _stockManager;
		private readonly IStockMovementManager _stockMovementManager;
        private readonly IProductManager _productManager;

		public SaleManager(ISaleRepository saleRepository, IStockManager stockManager, IStockMovementManager stockMovementManager,IProductManager productManager) : base(saleRepository)
		{
			_saleRepository = saleRepository;
			_stockManager = stockManager;
			_stockMovementManager = stockMovementManager;
            _productManager = productManager;
		}

		public async Task ProcessSaleAsync(Sale sale)
		{
			await _saleRepository.ProcessSaleASync(sale);	
			await _stockManager.UpdateStockAfterSaleAsync(sale.ProductId, sale.SalesQuantity);
		}

		public async Task AddSaleByUpdateMovement(Sale sale)
		{
			await _saleRepository.AddASync(sale);

			


		}
        public async Task<Sale> GetTopSaledProductAsync()
        {
          return  await _saleRepository.GetTopSaledProductAsync();
        }

        public Decimal GetTotalEarn()
        {
            var saleList=_saleRepository.GetActives();

			var total=  saleList.Sum(s=>s.SalesQuantity* s.Product.Price);

			return total;
        }

        public async Task<List<GetTopCategories>> GetTopSaleCategories()
        {
            var sales = await _saleRepository.GetActives().Include(s=>s.Product).ThenInclude(p=>p.Category).ToListAsync();

            var topCategories = sales
                .GroupBy(s => s.Product.Category)
                .Select(categoryGroup => new GetTopCategories
                {
                    CategoryName = categoryGroup.Key.Name,
                    TotalSalesQuantity = categoryGroup.Sum(s => s.SalesQuantity)
                })
                .OrderByDescending(cs => cs.TotalSalesQuantity)
                .Take(4)
                .ToList();

            return topCategories;
        }
    }
}
