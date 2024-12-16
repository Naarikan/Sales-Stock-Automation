using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blazor.BLL.Managers.Abstract;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Interfaces;

namespace Blazor.BLL.Managers.Concrete
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected readonly IRepository<T> _irp;
        public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }

        public async Task AddASync(T item)
        {
           await _irp.AddASync(item);
        }

        public async Task DeleteAsync(T item)
        {
          await _irp.DeleteAsync(item);
        }

        public async Task DestroyAsync(T item)
        {
            await _irp.DestroyAsync(item);
        }

        public async Task<T> FilterFirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _irp.FilterFirstOrDefaultAsync(exp);
        }

		public IQueryable<T> GetActives()
		{
			return _irp.GetActives();
		}

		public List<T> GetAllList()
        {
           return _irp.GetAllList();
        }

        public IQueryable<T> GetAllQueryable()
        {
           return _irp.GetAllQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _irp.GetByIdAsync(id);
        }

        public async Task<T> GetByNameAsync(string name)
        {
           return await _irp.GetByNameAsync(name);
        }

		public IQueryable<T> GetFilter(Expression<Func<T, bool>> predicate)
		{
			return _irp.GetFilter(predicate);
		}

		public async Task UpdateAsync(T item)
        {
         await _irp.UpdateAsync(item);
        }
    }
}
