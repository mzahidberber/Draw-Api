using Draw.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DrawBoxController : CustomBaseController
    {
        [HttpGet("drawBoxes")]
        public async Task<IActionResult> GetDrawBoxes()
        {
            return ActionResultInstance(await _drawBoxManager.GetAllAsync());
        }

        [HttpPost("drawBoxes/add")]
        public async Task<IActionResult> AddDrawBoxes(DrawBoxRequest request)
        {
            return ActionResultInstance(await _drawBoxManager.AddAllAsync(request.drawBoxes));
        }

        [HttpDelete("drawBoxes/delete")]
        public async Task<IActionResult> DeleteDrawBoxes(List<int> ids)
        {
            return ActionResultInstance(await _drawBoxManager.DeleteAllAsync(ids));
        }

        [HttpPut("drawBoxes/update")]
        public async Task<IActionResult> UpdateDrawBoxes(DrawBoxRequest request)
        {
            return ActionResultInstance(await _drawBoxManager.UpdateAllAsync(request.drawBoxes));
        }

        [HttpGet("drawBoxes/{id}")]
        public async Task<IActionResult> GetDrawBox(int id)
        {
            return ActionResultInstance(await _drawBoxManager.GetAsync(id));
        }

        [HttpGet("drawBoxes/{id}/layers")]
        public async Task<IActionResult> GetLayers(int id)
        {
            return ActionResultInstance(await _drawBoxManager.GetLayersAsync(id));
        }

    }
}
