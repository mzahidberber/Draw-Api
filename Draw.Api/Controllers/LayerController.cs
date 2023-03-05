using Draw.Api.Models;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LayerController:CustomBaseController
    {
        private ILayerService _layerManager;

        public LayerController()
        {
            _layerManager = InstanceFactory.GetInstance<ILayerService>();
        }
        
        [HttpGet("layers")]
        public async Task<Response<IEnumerable<LayerDTO>>> GetLayers()
        {
            return await _layerManager.GetAllAsync();
        }

        [HttpPost("layers/add")]
        public async Task<Response<IEnumerable<LayerDTO>>> AddLayers(LayerRequest layers)
        {
            return await _layerManager.AddAllAsync(layers.layers);
        }

        [HttpDelete("layers/delete")]
        public async Task<Response<NoDataDto>> DeleteLayers(List<int> ids)
        {
            return await _layerManager.DeleteAllAsync(ids);
        }

        [HttpPut("layers/update")]
        public async Task<Response<NoDataDto>> UpdateLayers(LayerRequest layers)
        {
            return await _layerManager.UpdateAllAsync(layers.layers);
        }

        [HttpGet("layers/{id}")]
        public async Task<Response<LayerDTO>> GetLayer(int id)
        {
            return await _layerManager.GetAsync(id);
        }

        [HttpGet("layers/{id}/elements")]
        public async Task<Response<IEnumerable<ElementDTO>>> GetElements(int id)
        {
            return await _layerManager.GetElementsAsync(id);
        }

        [HttpGet("layers/{id}/pen")]
        public async Task<Response<PenDTO>> GetPen(int id)
        {
            return await _layerManager.GetPenAsync(id);
        }

        
    }
}
