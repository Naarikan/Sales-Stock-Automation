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
    public class CategoryManager:BaseManager<Category>,ICategoryManager
    {
        ICategoryRepository _ıcr;
        public CategoryManager(ICategoryRepository ıcr):base(ıcr)
        {
            _ıcr=ıcr;
        }
    }
}
