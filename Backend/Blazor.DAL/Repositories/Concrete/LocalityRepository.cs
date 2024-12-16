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
    public class LocalityRepository : BaseRepository<Locality>, ILocalityRepository
    {
        public LocalityRepository(MyContext db) : base(db)
        {
        }

		public async Task<Locality> GetByParentId(int parentId)
		{

			return await _db.Set<Locality>().FirstOrDefaultAsync(x=>x.ParentId==parentId);
		}
	}
}
