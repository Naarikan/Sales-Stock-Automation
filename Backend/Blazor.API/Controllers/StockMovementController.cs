using Blazor.API.ViewModels.StockMovement;
using Blazor.BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
    [Authorize(Roles = "admin,stock")]
    public class StockMovementController : ControllerBase
	{
		IStockMovementManager _manager;

		public StockMovementController(IStockMovementManager manager)
		{
			_manager = manager;
		}

		[HttpGet("blazor.api/stockmovement/getmovements")]
		public IActionResult GetMovements()
		{
			var movements=_manager.GetActives().Select(s=>new GetMovementsViewModel { 
			
			Id = s.Id,
			CreatedDate=s.CreatedDate,
			ModifiedDate=s.ModifiedDate,
			Movement=s.Movement,
			Stock=s.Stock.Quantity,
			StockId=s.StockId,
			ProductName=s.Stock.Product.Name,
			});
			return Ok(movements);

		}
	}
}
