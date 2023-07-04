using Draw.Api.Models;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Aspects.PostSharp.LoggingAspects;
using Draw.Core.Business.Abstract;
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
        [LogAspect]
        [HttpGet("points")]
        public async Task<IActionResult> GetPoints()
        {
            return ActionResultInstance(await _pointManager.GetAllAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpGet("pointsbyelement")]
        public async Task<IActionResult> GetPointsByElement(int elementId)
        {
            return ActionResultInstance(await _pointManager.GetAllByElementAsync(GetUserInfo(User).id,elementId));
        }
        [LogAspect]
        [HttpGet("pointsbylayer")]
        public async Task<IActionResult> GetPointsByLayer(int layerId)
        {
            return ActionResultInstance(await _pointManager.GetAllByLayerAsync(GetUserInfo(User).id,layerId));
        }
        [LogAspect]
        [HttpGet("pointsbydraw")]
        public async Task<IActionResult> GetPointsByDraw(int drawId)
        {
            return ActionResultInstance(await _pointManager.GetAllByDrawAsync(GetUserInfo(User).id,drawId));
        }
        [LogAspect]
        [HttpPost("points/add")]
        public async Task<IActionResult> AddPoint(PointRequest request)
        {
            return ActionResultInstance(await _pointManager.AddAllAsync(request.points));
        }
        [LogAspect]
        [HttpDelete("points/delete")]
        public async Task<IActionResult> DeletePoints(List<int> ids)
        {   
            return ActionResultInstance(await _pointManager.DeleteAllAsync(GetUserInfo(User).id, ids));
        }
        [LogAspect]
        [HttpPut("points/update")]
        public async Task<IActionResult> UpdatePoints(PointRequest request)
        {
            return ActionResultInstance(await _pointManager.UpdateAllAsync(GetUserInfo(User).id, request.points));
        }
        [LogAspect]
        [HttpGet("points/{id}")]
        public async Task<IActionResult> GetPoint(int id)
        {
            return ActionResultInstance(await _pointManager.GetAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("points/{id}/element")]
        public async Task<IActionResult> GetElement(int id)
        {
            return ActionResultInstance(await _pointManager.GetElementAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("points/{id}/pointtype")]
        public async Task<IActionResult> GetPointType(int id)
        {
            return ActionResultInstance(await _pointManager.GetPointTypeAsync(GetUserInfo(User).id, id));
        }
    }
}
