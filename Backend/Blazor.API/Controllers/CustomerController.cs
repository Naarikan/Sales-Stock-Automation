using Blazor.API.ViewModels.Customer;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,stock,sales")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _manager;

        public CustomerController(ICustomerManager manager)
        {
            _manager = manager;
        }

        [HttpGet("blazor.api/customer/getcustomers/")]
        public IActionResult GetCustomers()
        {
            var customers = _manager.GetAllQueryable();
            return Ok(customers);
        }


        [HttpPost("blazor.api/customer/addcustomer/")]
        public async Task<IActionResult> AddCustomer(AddCustomerModel customerModel)
        {
            if (customerModel == null)
            {
                return NotFound("İşlem Başarısız");
            }

            Customer newCustomer = new Customer()
            {
                Address = customerModel.Address,
                PhoneNumber = customerModel.PhoneNumber,
                Name = customerModel.Name,
            };

            await _manager.AddASync(newCustomer);
            return Ok("İşlem Başarılı");
        }

        [HttpGet("blazor.api/customergetbyid/{id}")]
        public async Task<IActionResult> CustomerGetById(int id)
        {
            var customer = await _manager.GetByIdAsync(id);
            return Ok(customer);
        }


        [HttpGet("blazor.api/customergetbyname/{name}")]
        public async Task<IActionResult> CustomerGetByName(string name)
        {
            var customer = await _manager.FilterFirstOrDefaultAsync(n => n.Name == name);
            return Ok(customer);
        }





        [HttpPost("blazor.api/customer/updatecustomer/")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerModel customerModel)
        {
           

            var customer = await _manager.GetByIdAsync(customerModel.Id);
            if (customer == null)
            {
                return NotFound("Bulunamadı");
            }
            Customer updatedCustomer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Address = customerModel.Address,
                PhoneNumber = customerModel.PhoneNumber,
            };

            await _manager.UpdateAsync(updatedCustomer);
            return Ok("Customer updated successfully.");
        }

        [HttpDelete("blazor.api/customer/deletecustomer/{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            var customer = await _manager.GetByIdAsync(id);
            await _manager.DeleteAsync(customer);
            return Ok("Silme Başarılı");

        }

        [HttpDelete("blazor.api/customer/destroycustomer/{id}")]
        public async Task<IActionResult> DestroyCustomerById(int id)
        {
            var customer = await _manager.GetByIdAsync(id);
            await _manager.DestroyAsync(customer);
            return Ok("Kayıt Tamamen Silindi ");

        }


    }
}
