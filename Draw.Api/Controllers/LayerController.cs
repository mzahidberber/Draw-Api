using Draw.Api.Models.Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LayerController : CustomBaseController
    {
        [HttpGet("layers")]
        public async Task<IActionResult> GetLayers()
        {
            return ActionResultInstance(await _layerManager.GetAllAsync(GetUserId(User)));
        }

        [HttpPost("layers")]
        public async Task<IActionResult> GetLayersAtDraw(LayerDrawRequest draw)
        {
            return ActionResultInstance(await _layerManager.GetAllByDrawAsync(GetUserId(User), draw.drawId));
        }

        [HttpPost("layers/add")]
        public async Task<IActionResult> AddLayers(LayerRequest layers)
        {
            return ActionResultInstance(await _layerManager.AddAllAsync(layers.layers));
        }

        [HttpDelete("layers/delete")]
        public async Task<IActionResult> DeleteLayers(List<int> ids)
        {
            return ActionResultInstance(await _layerManager.DeleteAllAsync(GetUserId(User),ids));
        }

        [HttpPut("layers/update")]
        public async Task<IActionResult> UpdateLayers(LayerRequest layers)
        {
            return ActionResultInstance(await _layerManager.UpdateAllAsync(GetUserId(User), layers.layers));
        }

        [HttpGet("layers/{id}")]
        public async Task<IActionResult> GetLayer(int id)
        {
            return ActionResultInstance(await _layerManager.GetAsync(GetUserId(User), id));
        }

        [HttpGet("layers/{id}/elements")]
        public async Task<IActionResult> GetElements(int id)
        {
            return ActionResultInstance(await _layerManager.GetElementsAsync(GetUserId(User),id));
        }

        [HttpGet("layers/{id}/pen")]
        public async Task<IActionResult> GetPen(int id)
        {
            return ActionResultInstance(await _layerManager.GetPenAsync(GetUserId(User),id));
        }


    }
}
