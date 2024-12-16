using Blazor.API.ViewModels.Product;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,sales,stock")]
    public class ProductController : ControllerBase
    {
        IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        
        [HttpGet("blazor.api/product/getproducts")]
       
        public IActionResult GetProduct()
        {
            var products = _productManager.GetActives();
            return Ok(products);

        }

        [HttpPost("blazor.api/product/addproduct")]
        public async Task<IActionResult> AddProduct(AddProductModel addProductModel)
        {
            Product product = new Product
            {
                Name = addProductModel.Name,
                Price = addProductModel.Price,
                CategoryId=addProductModel.CategoryId,
            };

            await _productManager.AddASync(product);
            return Ok("");
        }

        [HttpPost("blazor.api/product/updateproduct")]
        public async Task<IActionResult> UpdatProduct(UpdateProductModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
            };

            await _productManager.UpdateAsync(product);
            return Ok("");
        }

        [HttpDelete("blazor.api/product/deleteproduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productManager.GetByIdAsync(id);
            await _productManager.DeleteAsync(product);
            return Ok();

        }

    }
}
