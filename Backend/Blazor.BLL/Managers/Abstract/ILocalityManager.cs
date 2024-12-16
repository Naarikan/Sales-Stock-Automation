using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Models;

namespace Blazor.BLL.Managers.Abstract
{
    public interface ILocalityManager:IManager<Locality>
    {
		Task<Locality> GetByParentId(int parentId);
	}
}
