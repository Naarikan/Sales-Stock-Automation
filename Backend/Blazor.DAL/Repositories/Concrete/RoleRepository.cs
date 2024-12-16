using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.DAL.Context;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Models;

namespace Blazor.DAL.Repositories.Concrete
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MyContext db) : base(db)
        {
        }
    }
}
