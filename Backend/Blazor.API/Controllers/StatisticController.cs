using Blazor.API.ViewModels.Statistic;
using Blazor.BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class StatisticController : ControllerBase
    {
        ISaleManager _saleManager;

        public StatisticController(ISaleManager saleManager)
        {
            _saleManager = saleManager;
        }

        [HttpGet("blazor.api/statistic/gettopsale")]
        public async Task<IActionResult> GetTopSale()
        {
            var sale = await _saleManager.GetTopSaledProductAsync();
            GetTopSaleModel model = new GetTopSaleModel()
            {
                ProductName = sale.Product.Name,
                Quantity = sale.SalesQuantity,
            };

            return Ok(model);

        }

        [HttpGet("blazor.api/statistic/gettotalearn")]
        public async Task<IActionResult> GetTotalEarn()
        {
            var money = _saleManager.GetTotalEarn();
            return Ok(money);

        }


        [HttpGet("blazor.api/statistic/gettopcategories")]
        public async Task<IActionResult> GetTopCategories() 
        {
            var categories = await _saleManager.GetTopSaleCategories();
            return Ok(categories);

        }
    }
}
