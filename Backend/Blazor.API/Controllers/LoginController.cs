using Blazor.API.Security;
using Blazor.API.ViewModels.Login;
using Blazor.API.ViewModels.Register;
using Blazor.BLL.Managers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NETCore.Encrypt;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public LoginController(IEmployeeManager employeeManager,IConfiguration configuration,IAuthService authService)
        {
            _configuration = configuration;
            _employeeManager = employeeManager;
            _authService = authService;
        }


        [HttpPost ("blazor.api/login/loginemployee")]
        public async Task<IActionResult> LoginEmployee([FromBody]LoginRequestModel loginModel)
        {
            var responseModel = await _authService.LoginAsync(loginModel);

            if (responseModel == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            return Ok(responseModel); 

        }

    }
}
