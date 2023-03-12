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
    public class DrawBoxController : CustomBaseController
    {
        private readonly IDrawBoxService _drawBoxManager;

        public DrawBoxController()
        {
            _drawBoxManager = BusinessInstanceFactory.GetInstance<IDrawBoxService>();
        }

        [HttpGet("drawBoxes")]
        public async Task<IActionResult> GetDrawBoxes()
        {
            return ActionResultInstance(await _drawBoxManager.GetAllAsync(GetUserId(User)));
        }

        [HttpPost("drawBoxes/add")]
        public async Task<IActionResult> AddDrawBoxes(DrawBoxRequest request)
        {
            return ActionResultInstance(await _drawBoxManager.AddAllAsync(request.drawBoxes));
        }

        [HttpDelete("drawBoxes/delete")]
        public async Task<IActionResult> DeleteDrawBoxes(List<int> ids)
        {
            return ActionResultInstance(await _drawBoxManager.DeleteAllAsync(GetUserId(User), ids));
        }

        [HttpPut("drawBoxes/update")]
        public async Task<IActionResult> UpdateDrawBoxes(DrawBoxRequest request)
        {
            return ActionResultInstance(await _drawBoxManager.UpdateAllAsync(GetUserId(User), request.drawBoxes));
        }

        [HttpGet("drawBoxes/{id}")]
        public async Task<IActionResult> GetDrawBox(int id)
        {
            return ActionResultInstance(await _drawBoxManager.GetAsync(GetUserId(User), id));
        }

        [HttpGet("drawBoxes/{id}/layers")]
        public async Task<IActionResult> GetLayers(int id)
        {
            return ActionResultInstance(await _drawBoxManager.GetLayersAsync(GetUserId(User), id));
        }

    }
}
