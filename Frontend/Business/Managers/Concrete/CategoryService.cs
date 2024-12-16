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
    public class CategoryService:ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryModel>>("https://localhost:7146/blazor.api/category/getcategories");
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryModel>($"https://localhost:7146/blazor.api/category/getcategory/{id}");
        }

        public async Task AddCategoryAsync(CategoryModel category)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/category/addcategory", category);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCategoryAsync(CategoryModel category)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7146/blazor.api/category/updatecategory/", category);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoryAsync(int id)
        {
			var response = await _httpClient.DeleteAsync($"https://localhost:7146/blazor.api/category/deletecategory/{id}");
			response.EnsureSuccessStatusCode();
		}

	
	}
}
