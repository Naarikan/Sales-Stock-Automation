using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
    public interface IStatisticService
    {
        Task<StatisticProductModel> GetTopSalesProductAsync();
        Task<Decimal> GetTotalEarnAsync();
        Task<List<GetTopCategoriesModel>> GetTopCategoriesAsync();
    }
}
