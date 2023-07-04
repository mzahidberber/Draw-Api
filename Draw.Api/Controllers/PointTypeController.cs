using Draw.Api.Models;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PointTypeController : CustomBaseController
    {
        private IPointTypeService _pointTypeService;

        public PointTypeController()
        {
            _pointTypeService = BusinessInstanceFactory.GetInstance<IPointTypeService>();
        }

        [Authorize]
        [HttpGet("pointTypes")]
        public async Task<IActionResult> GetPointTypes()
        {
            return ActionResultInstance(await _pointTypeService.GetAllAsync());
        }

        [Authorize]
        [HttpGet("pointTypes/{id}")]
        public async Task<IActionResult> GetPointType(int id)
        {
            return ActionResultInstance(await _pointTypeService.GetAllAsync());
        }

        [Authorize(Roles = "admin,manager")]
        [HttpPost("pointTypes/add")]
        public async Task<IActionResult> AddPointTypes(PointTypeRequest request)
        {
            return ActionResultInstance(await _pointTypeService.AddAllAsync(request.pointTypes));
        }

        [Authorize(Roles = "admin,manager")]
        [HttpDelete("pointTypes/delete")]
        public async Task<IActionResult> DeletePointTypes(List<int> ids)
        {
            return ActionResultInstance(await _pointTypeService.DeleteAllAsync( ids));
        }

        [Authorize(Roles = "admin,manager")]
        [HttpPut("pointTypes/update")]
        public async Task<IActionResult> UpdatePointTypes(PointTypeRequest request)
        {
            return ActionResultInstance(await _pointTypeService.UpdateAllAsync(request.pointTypes));
        }
    }
}
