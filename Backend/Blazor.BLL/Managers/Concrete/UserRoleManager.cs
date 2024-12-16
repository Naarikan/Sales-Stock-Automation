using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.Managers.Abstract;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;

namespace Blazor.BLL.Managers.Concrete
{
    public class UserRoleManager:BaseManager<UserRole>,IUserRoleManager
    {
        IUserRoleRepository _ırr;
        public UserRoleManager(IUserRoleRepository ırr):base(ırr)
        {
            _ırr=ırr;
        }

        public async Task<List<string>> GetUserRolesAsync(int userId)
        {
           return await _ırr.GetUserRolesAsync(userId);
        }
    }
}
