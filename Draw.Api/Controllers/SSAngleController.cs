using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.Aspects.PostSharp.LoggingAspects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SSAngleController : CustomBaseController
    {
        private ISSAngleService _ssangleManager;
        public SSAngleController()
        {
            _ssangleManager = BusinessInstanceFactory.GetInstance<ISSAngleService>();
        }
        [LogAspect]
        [HttpGet("ssangles")]
        public async Task<IActionResult> GetPoints()
        {
            return ActionResultInstance(await _ssangleManager.GetAllAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpPost("ssangles/add")]
        public async Task<IActionResult> AddPoint(SSAngleRequest request)
        {
            return ActionResultInstance(await _ssangleManager.AddAllAsync(request.ssangles));
        }
        [LogAspect]
        [HttpDelete("ssangles/delete")]
        public async Task<IActionResult> DeletePoints(List<int> ids)
        {   
            return ActionResultInstance(await _ssangleManager.DeleteAllAsync(GetUserInfo(User).id, ids));
        }
        [LogAspect]
        [HttpPut("ssangles/update")]
        public async Task<IActionResult> UpdatePoints(SSAngleRequest request)
        {
            return ActionResultInstance(await _ssangleManager.UpdateAllAsync(GetUserInfo(User).id, request.ssangles));
        }
        [LogAspect]
        [HttpGet("ssangles/{id}")]
        public async Task<IActionResult> GetPoint(int id)
        {
            return ActionResultInstance(await _ssangleManager.GetAsync(GetUserInfo(User).id, id));
        }
    }
}
