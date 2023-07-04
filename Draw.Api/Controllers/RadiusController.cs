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
    public class RadiusController : CustomBaseController
    {
        private IRadiusService _radiusManager;
        public RadiusController()
        {
            _radiusManager = BusinessInstanceFactory.GetInstance<IRadiusService>();
        }
        [LogAspect]
        [HttpGet("radiuses")]
        public async Task<IActionResult> GetPoints()
        {
            return ActionResultInstance(await _radiusManager.GetAllAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpPost("radiuses/add")]
        public async Task<IActionResult> AddPoint(RadiusRequest request)
        {
            return ActionResultInstance(await _radiusManager.AddAllAsync(request.radiuses));
        }
        [LogAspect]
        [HttpDelete("radiuses/delete")]
        public async Task<IActionResult> DeletePoints(List<int> ids)
        {   
            return ActionResultInstance(await _radiusManager.DeleteAllAsync(GetUserInfo(User).id, ids));
        }
        [LogAspect]
        [HttpPut("radiuses/update")]
        public async Task<IActionResult> UpdatePoints(RadiusRequest request)
        {
            return ActionResultInstance(await _radiusManager.UpdateAllAsync(GetUserInfo(User).id, request.radiuses));
        }
        [LogAspect]
        [HttpGet("radiuses/{id}")]
        public async Task<IActionResult> GetPoint(int id)
        {
            return ActionResultInstance(await _radiusManager.GetAsync(GetUserInfo(User).id, id));
        }
    }
}
