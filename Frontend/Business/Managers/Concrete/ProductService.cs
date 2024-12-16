using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Business.Managers.Abstract;
using Entities.Models;

namespace Business.Managers.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductModel>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductModel>>("https://localhost:7146/blazor.api/Product/getproducts");
        }

        

        public async Task AddProductAsync(ProductModel Product)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/Product/addproduct", Product);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateProductAsync(ProductModel Product)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/Product/updateproduct/", Product);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/Product/deleteproduct/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
