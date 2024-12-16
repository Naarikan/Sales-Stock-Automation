using Blazor.API.ViewModels.Category;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.API.Controllers
{
	//[Route("api/[controller]")]
	[ApiController]
    [Authorize(Roles ="admin,sales,stock")]
    public class CategoryController : ControllerBase
    {
        ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("blazor.api/category/getcategories")]
        public IActionResult GetCategories()
        {
            var categories = _categoryManager.GetActives();


            var categoryViewModels = categories.Select(c => new GetCategoryViewModel
            {
                Id = c.Id,
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate,
                DeletedDate = c.DeletedDate,
                Name = c.Name
            }).ToList();

            return Ok(categoryViewModels);

        }
        [HttpPost("blazor.api/category/addcategory")]
        public async Task<IActionResult> AddCategory(AddCategoryModel addCategoryModel)
        {
            var newCategory = new Entities.Models.Category()
            {
                Name = addCategoryModel.Name,
            };

            await _categoryManager.AddASync(newCategory);
            return Ok();
        }

        [HttpDelete("blazor.api/category/deletecategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        { 
            
            var category1 = await _categoryManager.GetByIdAsync(id);
            await _categoryManager.DeleteAsync(category1);
            return Ok();
        }

        [HttpPost("blazor.api/category/updatecategory/")]
        public async Task< IActionResult> UpdateCategory(UpdateCategoryModel model)
        {
            var category = await _categoryManager.GetByIdAsync(model.Id);

            if (category == null)
            {

                return NotFound("Bulamadık Hocam");
            }
            else
            {
                Category updatedCategory = new Category()
                {
                    Id = model.Id,
                    Name = model.Name,
                };
                await _categoryManager.UpdateAsync(updatedCategory);
                return Ok();
            }

        }

        [HttpGet("blazor.api/category/getcategory/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryManager.GetByIdAsync(id);
            return Ok(category);
        }

	}
}
