using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.ComplexModels;
using Blazor.Entities.Models;

namespace Blazor.BLL.Managers.Abstract
{
    public interface ISaleManager : IManager<Sale>
    {
		Task ProcessSaleAsync(Sale sale);

        //Statistic Methods
        Task<Sale> GetTopSaledProductAsync();

        Decimal GetTotalEarn();

        Task<List<GetTopCategories>> GetTopSaleCategories();

	}
}
