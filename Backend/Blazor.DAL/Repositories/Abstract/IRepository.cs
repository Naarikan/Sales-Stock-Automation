﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blazor.Entities.Interfaces;

namespace Blazor.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : class,IEntity
    {
        IQueryable<T> GetAllQueryable();
        List<T> GetAllList();

        IQueryable<T> GetFilter(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetActives();
        IQueryable<T> GetPassives();

        Task AddASync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task DestroyAsync(T item);


        Task<T> GetByIdAsync(int id);
        Task<T> GetByNameAsync(string name);

        Task<T> FilterFirstOrDefaultAsync(Expression<Func<T, bool>> exp);
    }
}