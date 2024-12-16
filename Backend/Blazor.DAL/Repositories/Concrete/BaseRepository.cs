using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blazor.DAL.Context;
using Blazor.DAL.Repositories.Abstract;
using Blazor.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazor.DAL.Repositories.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
		protected MyContext _db;

        public BaseRepository(MyContext db)
        {
            _db = db;
        }

        public async Task AddASync(T item)
        {
           await _db.Set<T>().AddAsync(item);
           await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            item.Status = Entities.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            await _db.SaveChangesAsync();
        }

        public async Task DestroyAsync(T item)
        {
           _db.Set<T>().Remove(item);
           await _db.SaveChangesAsync();
        }

        public async Task<T> FilterFirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
            return _db.Set<T>().Where(x => x.Status != Entities.Enums.DataStatus.Deleted);
        }

        public List<T> GetAllList()
        {
           return _db.Set<T>().ToList();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _db.Set<T>().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByNameAsync(string name)
        {
            return await _db.Set<T>().FindAsync(name);
        }

		public IQueryable<T> GetFilter(Expression<Func<T, bool>> predicate)
		{
            return _db.Set<T>().Where(predicate);
		}

		public IQueryable<T> GetPassives()
        {
            return _db.Set<T>().Where(x=>x.Status==Entities.Enums.DataStatus.Deleted);
        }

        public async Task UpdateAsync(T item)
        {
            item.Status = Entities.Enums.DataStatus.Uptaded;
            item.ModifiedDate = DateTime.Now;
            T original = await GetByIdAsync(item.Id);
            _db.Entry(original).CurrentValues.SetValues(item);
            await _db.SaveChangesAsync();

        }
    }
}
