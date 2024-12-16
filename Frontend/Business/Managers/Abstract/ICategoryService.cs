using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetCategoriesAsync();
        Task<CategoryModel> GetCategoryByIdAsync(int id);

        Task AddCategoryAsync(CategoryModel category);
        Task UpdateCategoryAsync(CategoryModel category);
        Task DeleteCategoryAsync(int id);
    }
}
