using Blazor.API.ViewModels.Stock;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{



    [ApiController]
    [Authorize(Roles = "admin,stock")]
    public class StockController : ControllerBase
    {
        IStockManager _stockManager;
        IProductManager _productManager;

        public StockController(IStockManager stockManager, IProductManager productManager)
        {
            _stockManager = stockManager;
            _productManager = productManager;
        }

        [HttpGet("blazor.api/stock/getstocks")]
        public IActionResult GetStocks()
        {
            var stocks = _stockManager.GetActives()

          .Select(s => new StockListModel
          {
              Id = s.Id,
              Quantity = s.Quantity,
              ProductId = s.ProductId,
              Product = s.Product.Name,
              ProductCategory = s.Product.Category.Name,
              CreatedDate = s.CreatedDate,

          });

            return Ok(stocks);
        }


        [HttpPost("blazor.api/stock/addstock")]
        public async Task<IActionResult> AddStock(AddStockModel addStock)
        {
            Stock stock = new Stock()
            {
                Quantity = addStock.Quantity,
                ProductId = addStock.ProductId,

            };
            await _stockManager.AddASync(stock);
            return Ok();

        }

        [HttpDelete("blazor.api/stock/deletestock/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _stockManager.GetByIdAsync(id);
            await _stockManager.DeleteAsync(stock);
            return Ok();

        }

        [HttpPost("blazor.api/stock/updatestock")]
        public async Task<IActionResult> UpdateStock(UpdateStockModel model)
        {
            Stock stock = new()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                ProductId = model.ProductId,
                

            };
            await _stockManager.IncreaseOrUpdateStockAsync(stock,model.UpdateName);
            return Ok();

        }

	}
}
