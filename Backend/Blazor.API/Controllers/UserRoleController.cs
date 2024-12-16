using Blazor.API.ViewModels.UserRole;
using Blazor.BLL.Managers.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class UserRoleController : ControllerBase
    {
        IUserRoleManager _userRoleManager;

        public UserRoleController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }

        [HttpGet("blazor.api/userrole/getuserroles")]
        public async Task<IActionResult> GetUserRoles(int id)
        {
            var userRoles = await _userRoleManager.GetUserRolesAsync(id);
            return Ok(userRoles);

        }
    }
}
