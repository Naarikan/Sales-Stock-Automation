using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blazor.API.ViewModels.Login;
using Blazor.Entities.Security;

namespace Blazor.API.Security
{
    public interface IAuthService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel model);
        
    }
}
