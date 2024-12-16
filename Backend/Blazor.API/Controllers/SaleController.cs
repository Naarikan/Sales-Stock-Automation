using Blazor.API.ViewModels.Sales;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace Blazor.API.Controllers
{
	
	[ApiController]
    [Authorize(Roles = "admin,sales")]
    public class SaleController : ControllerBase
	{
		ISaleManager _saleManager;

		public SaleController(ISaleManager saleManager)
		{
			_saleManager = saleManager;
		}

		[HttpGet("blazor.api/sale/getsales")]
		public async Task<IActionResult> GetSales()
		{
			var sales = _saleManager.GetActives().
				Select(s=>new GetSalesModel
				{ 
				Id = s.Id,
				ProductId = s.ProductId,
				CategoryId=s.Product.CategoryId,
				ProductName=s.Product.Name,
				CategoryName=s.Product.Category.Name,
                EmployyeId=s.EmployeeId,
				EmployeeName=s.Employee.FirstName+" "+s.Employee.LastName,
				SalesQuantity=s.SalesQuantity,
				SaleTime=s.CreatedDate,
				TotalAmount=s.Product.Price*s.SalesQuantity ,
				CustomerId=s.CustomerId,
				CustomerName=s.Customer.Name,
				});
			return Ok(sales);
		}

		[HttpPost("blazor.api/sale/addsale")]
		public async Task<IActionResult> AddSale(AddSaleModel model)
		{
			Sale sale = new Sale()
			{
				SalesQuantity = model.SalesQuantity,
				CustomerId = model.CustomerId,
				EmployeeId= model.EmployyeId,
				ProductId= model.ProductId,
			};
			await _saleManager.ProcessSaleAsync(sale);
			return Ok();
		}

		[HttpDelete("blazor.api/sale/deletesale/{id}")]
		public async Task<IActionResult> DeleteSale(int id)
		{
			var sale=await _saleManager.GetByIdAsync(id);
			await _saleManager.DeleteAsync(sale);
			return Ok();

		}

		[HttpGet("blazor.api/sale/gettotalearn")]
		public async Task<IActionResult> GetTotalEarn()
		{
			var money=_saleManager.GetTotalEarn();
			return Ok(money);

		}

    }
}
