using System.Runtime.InteropServices;
using Blazor.BLL.Managers.Abstract;
using Blazor.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Blazor.API.ViewModels.Locality;
using Microsoft.AspNetCore.Authorization;

namespace Blazor.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles ="admin")]
    public class LocalityController : ControllerBase
    {
        ILocalityManager _localityManager;
        public LocalityController(ILocalityManager localityManager)
        {
            _localityManager = localityManager;
        }

        [HttpGet("blazor.api/locality/getlocalities")]
        public IActionResult GetLocalities()
        {
           var localities=_localityManager.GetActives();
           return Ok(localities);

        }

		[HttpGet("blazor.api/locality/getbyparent/{parentId}")]
		public IActionResult GetSubLocalityByParentIdList(int parentId)
		{
            var subLocalities = _localityManager.GetFilter(x=>x.ParentId==parentId);
			return Ok(subLocalities);

		}

		[HttpGet("blazor.api/locality/getlocalitybyid/{parentId}")]
		public async Task< IActionResult> GetBaseLocalityById(int parentId)
		{
			var subLocality = await _localityManager.GetByIdAsync(parentId);
			return Ok(subLocality);

		}


		[HttpPost("blazor.api/locality/addlocality")]
        public async Task<IActionResult> AddLocality(AddLocalityModel localityModel)
        {
            Locality locality = new Locality()
            {
                Name = localityModel.Name,
                ParentId = localityModel.ParentId,
            };

            await _localityManager.AddASync(locality);
            return Ok();
        }

        [HttpDelete("blazor.api/locality/deletelocality/{id}")]
        public async Task<IActionResult> DeleteLocality(int id)
        {
            var locality = await _localityManager.GetByIdAsync(id);
            await _localityManager.DeleteAsync(locality);
            return Ok();

        }

        [HttpPost("blazor.api/locality/updatelocality")]
        public async Task<IActionResult> UpdateLocality(UpdateLocalityModel localityModel)
        {
            Locality locality = new Locality()
            {
                Id = localityModel.Id,
                Name= localityModel.Name,
                ParentId = localityModel.ParentId,
            };

            await _localityManager.UpdateAsync(locality);
            return Ok();
        }

		[HttpGet("blazor.api/locality/getlocality/{parentid}")]
		public IActionResult GetLocaliyByParentId(int parentid)
		{
			var locality = _localityManager.GetByParentId(parentid);
			return Ok(locality);

		}
	}
}
