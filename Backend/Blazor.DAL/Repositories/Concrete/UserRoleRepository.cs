using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.DAL.Context;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Repositories.Concrete
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
       
        
        public UserRoleRepository(MyContext db) : base(db)
        {
        }

        public async Task<List<string>> GetUserRolesAsync(int userId)
        {
            return await _db.Set<UserRole>()
                            .Include(ur => ur.Role) 
                            .Where(ur => ur.EmployeeId == userId)
                            .Select(ur => ur.Role.RoleName) 
                            .ToListAsync();
        }

      
    }
}
