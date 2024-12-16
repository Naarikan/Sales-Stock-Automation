using Blazor.API.ViewModels.Register;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IConfiguration _configuration;
        public RegisterController(IEmployeeManager employeeManager, IConfiguration configuration)
        {
            _employeeManager = employeeManager;
            _configuration = configuration;

        }

        [HttpPost ("blazor.api/register/register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            string sha256salt = _configuration.GetValue<string>("AppSettings:SHA256SALT");


            string Password = registerModel.Password+sha256salt;
            string hashedPassword = EncryptProvider.Sha256(Password);

            Employee newEmp = new Employee()
            {
                Email=registerModel.Email,
                FirstName=registerModel.FirstName,
                LastName=registerModel.LastName,
                PasswordHash=hashedPassword,
                PhoneNumber=registerModel.PhoneNumber,
                Address=registerModel.Address,
            };

            await _employeeManager.AddASync(newEmp);
            return Ok("Kayıt Eklendi");
        }
            
    }
}
