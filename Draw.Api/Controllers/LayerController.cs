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
    public class LayerController : CustomBaseController
    {
        private readonly ILayerService _layerManager;

        public LayerController()
        {
            _layerManager = BusinessInstanceFactory.GetInstance<ILayerService>();
        }
        [LogAspect]
        [HttpGet("layers")]
        public async Task<IActionResult> GetLayers()
        {
            return ActionResultInstance(await _layerManager.GetAllAsync(GetUserInfo(User).id));
        }
        [LogAspect]
        [HttpPost("layerswithpen")]
        public async Task<IActionResult> GetLayersWithPen(int drawId)
        {
            return ActionResultInstance(await _layerManager.GetAllByDrawWithPenAsync(GetUserInfo(User).id,drawId));
        }
        [LogAspect]
        [HttpPost("layers")]
        public async Task<IActionResult> GetLayersAtDraw(int drawId)
        {
            return ActionResultInstance(await _layerManager.GetAllByDrawAsync(GetUserInfo(User).id, drawId));
        }
        [LogAspect]
        [HttpPost("layers/add")]
        public async Task<IActionResult> AddLayers(LayerRequest layers)
        {
            return ActionResultInstance(await _layerManager.AddAllAsync(layers.layers));
        }
        [LogAspect]
        [HttpDelete("layers/delete")]
        public async Task<IActionResult> DeleteLayers(List<int> ids)
        {
            return ActionResultInstance(await _layerManager.DeleteAllAsync(GetUserInfo(User).id,ids));
        }
        [LogAspect]
        [HttpPut("layers/update")]
        public async Task<IActionResult> UpdateLayers(LayerRequest layers)
        {
            return ActionResultInstance(await _layerManager.UpdateAllAsync(GetUserInfo(User).id, layers.layers));
        }
        [LogAspect]
        [HttpGet("layers/{id}")]
        public async Task<IActionResult> GetLayer(int id)
        {
            return ActionResultInstance(await _layerManager.GetAsync(GetUserInfo(User).id, id));
        }
        [LogAspect]
        [HttpGet("layers/{id}/elements")]
        public async Task<IActionResult> GetElements(int id)
        {
            return ActionResultInstance(await _layerManager.GetElementsAsync(GetUserInfo(User).id,id));
        }
        [LogAspect]
        [HttpGet("layers/{id}/pen")]
        public async Task<IActionResult> GetPen(int id)
        {
            return ActionResultInstance(await _layerManager.GetPenAsync(GetUserInfo(User).id,id));
        }


    }
}
