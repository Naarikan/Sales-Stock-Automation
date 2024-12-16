using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProductsAsync();
        Task AddProductAsync(ProductModel Product);
        Task UpdateProductAsync(ProductModel Product);
        Task DeleteProductAsync(int id);
    }
}
