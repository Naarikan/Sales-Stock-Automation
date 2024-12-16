using Blazor.API.ViewModels.Category;
using Blazor.API.ViewModels.Employee;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
	//[Route("api/[controller]")]
	
	[ApiController]
   
    public class EmployeeController : ControllerBase
	{
		IEmployeeManager _ep;
		public EmployeeController(IEmployeeManager employeeManager)
		{
			_ep = employeeManager;
		}



		[HttpGet("blazor.api/employee/getemployees")]

        [Authorize(Roles = "admin,sales,stock")]
        public IActionResult GetEmployees()
		{
			var employees = _ep.GetActives();


			var employeeViewModels = employees.Select(c => new ListEmployeeModel
			{
				Id = c.Id,
				CreatedDate = c.CreatedDate,
				Address = c.Address,
				Email = c.Email,
				FirstName = c.FirstName,
				LastName = c.LastName,
				PhoneNumber = c.PhoneNumber,
				IsConfirmed = c.IsConfirmed,
				

			}).ToList();

			return Ok(employeeViewModels);
		}
        [Authorize(Roles = "admin")]
        [HttpPost("blazor.api/employee/confirm")]
		public async Task<IActionResult> Confirm([FromBody] int id)
		{
			await _ep.ConfirmEmployee(id);
			return Ok();

		}
        [Authorize(Roles = "admin")]
        [HttpPost("blazor.api/employee/updatestat")]
		public async Task<IActionResult> UpdateStat(UpdateEmployeeConfirmModel model)
		{
			Employee employee = new Employee()
			{
				Id=model.Id,
				IsConfirmed=model.IsConfirmed,
			};
			await _ep.UpdateAsync(employee);
			return Ok();

		}
        [Authorize(Roles = "admin")]
        [HttpDelete("blazor.api/employee/delete/{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var employee = await _ep.GetByIdAsync(id);
			await _ep.DeleteAsync(employee);
			return Ok();
		}
        [Authorize(Roles = "admin")]
        [HttpDelete("blazor.api/employee/rejectordestroy/{id}")]
		public async Task<IActionResult> RejectOrDestroy(int id)
		{
			var employee = await _ep.GetByIdAsync(id); 
			await _ep.DestroyAsync(employee);
			return Ok();
		}

        [HttpGet("blazor.api/employee/getemployee/{id}")]
        //[Authorize(Roles = "admin,sales")]
		public async Task<IActionResult> EmployeeGetById(int id) { 
		
			var employee= await _ep.GetByIdAsync(id);
			return Ok(employee);
		
		}
	}
}
