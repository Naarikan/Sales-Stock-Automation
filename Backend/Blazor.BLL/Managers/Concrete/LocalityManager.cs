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
    public class LocalityManager:BaseManager<Locality>,ILocalityManager
    {
        ILocalityRepository _ılr;
        public LocalityManager(ILocalityRepository ılr):base(ılr)
        {
            _ılr=ılr;
        }

		public async Task<Locality> GetByParentId(int parentId)
		{
            return await _ılr.GetByParentId(parentId);
		}
	}
}
