using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Models;

namespace Blazor.DAL.Repositories.Abstract
{
    public interface IUserRoleRepository:IRepository<UserRole>
    {
        Task<List<string>> GetUserRolesAsync(int userId);

    }
}
