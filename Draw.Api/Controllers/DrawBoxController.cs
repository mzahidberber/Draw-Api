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
    public class DrawBoxController : CustomBaseController
    {
        private readonly IDrawBoxService _drawBoxManager;

        public DrawBoxController()
        {
            _drawBoxManager = BusinessInstanceFactory.GetInstance<IDrawBoxService>();
        }

        [LogAspect]
        [HttpGet("drawBoxes")]
        public async Task<IActionResult> GetDrawBoxes()
        {
            return ActionResultInstance(await _drawBoxManager.GetAllAsync(GetUserInfo(User).id));
        }

        [LogAspect]
        [HttpPost("drawBoxes/add")]
        public async Task<IActionResult> AddDrawBoxes(DrawBoxRequest request)
        {
            request.drawBoxes.ForEach((d) => { d.UserId = GetUserId(); });
            return ActionResultInstance(await _drawBoxManager.AddAllAsync(request.drawBoxes));
        }

        [LogAspect]
        [HttpDelete("drawBoxes/delete")]
        public async Task<IActionResult> DeleteDrawBoxes(List<int> ids)
        {
            return ActionResultInstance(await _drawBoxManager.DeleteAllAsync(GetUserInfo(User).id, ids));
        }

        [LogAspect]
        [HttpPut("drawBoxes/update")]
        public async Task<IActionResult> UpdateDrawBoxes(DrawBoxRequest request)
        {
            request.drawBoxes.ForEach((d) => { d.UserId = GetUserId(); });
            return ActionResultInstance(await _drawBoxManager.UpdateAllAsync(GetUserInfo(User).id, request.drawBoxes));
        }

        [LogAspect]
        [HttpGet("drawBoxes/{id}")]
        public async Task<IActionResult> GetDrawBox(int id)
        {
            return ActionResultInstance(await _drawBoxManager.GetAsync(GetUserInfo(User).id, id));
        }

        [LogAspect]
        [HttpGet("drawBoxes/{id}/layers")]
        public async Task<IActionResult> GetLayers(int id)
        {
            return ActionResultInstance(await _drawBoxManager.GetLayersAsync(GetUserInfo(User).id, id));
        }

    }
}
