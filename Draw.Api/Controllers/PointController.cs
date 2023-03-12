using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PointController : CustomBaseController
    {
        private IPointService _pointManager;
        public PointController()
        {
            _pointManager = BusinessInstanceFactory.GetInstance<IPointService>();
        }

        [HttpGet("points")]
        public async Task<IActionResult> GetPoints()
        {
            return ActionResultInstance(await _pointManager.GetAllAsync(GetUserId(User)));
        }

        [HttpGet("pointsbyelement")]
        public async Task<IActionResult> GetPointsByElement(int elementId)
        {
            return ActionResultInstance(await _pointManager.GetAllByElementAsync(GetUserId(User),elementId));
        }

        [HttpGet("pointsbylayer")]
        public async Task<IActionResult> GetPointsByLayer(int layerId)
        {
            return ActionResultInstance(await _pointManager.GetAllByLayerAsync(GetUserId(User),layerId));
        }

        [HttpGet("pointsbydraw")]
        public async Task<IActionResult> GetPointsByDraw(int drawId)
        {
            return ActionResultInstance(await _pointManager.GetAllByDrawAsync(GetUserId(User),drawId));
        }

        [HttpPost("points/add")]
        public async Task<IActionResult> AddPoint(PointRequest request)
        {
            return ActionResultInstance(await _pointManager.AddAllAsync(request.points));
        }

        [HttpDelete("points/delete")]
        public async Task<IActionResult> DeletePoints(List<int> ids)
        {
            return ActionResultInstance(await _pointManager.DeleteAllAsync(GetUserId(User), ids));
        }

        [HttpPut("points/update")]
        public async Task<IActionResult> UpdatePoints(PointRequest request)
        {
            return ActionResultInstance(await _pointManager.UpdateAllAsync(GetUserId(User), request.points));
        }

        [HttpGet("points/{id}")]
        public async Task<IActionResult> GetPoint(int id)
        {
            return ActionResultInstance(await _pointManager.GetAsync(GetUserId(User), id));
        }

        [HttpGet("points/{id}/element")]
        public async Task<IActionResult> GetElement(int id)
        {
            return ActionResultInstance(await _pointManager.GetElementAsync(GetUserId(User), id));
        }

        [HttpGet("points/{id}/pointtype")]
        public async Task<IActionResult> GetPointType(int id)
        {
            return ActionResultInstance(await _pointManager.GetPointTypeAsync(GetUserId(User), id));
        }
    }
}
