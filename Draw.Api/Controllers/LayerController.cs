using Draw.Api.Models.LayerRequest;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.DTOs;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
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
        public async Task<Response<IEnumerable<Layer>>> GetLayers(UserDrawBoxIdRequest request)
        {
            return await _layerManager.GetAllAsync();
        }

        [HttpPost("layers/add")]
        public async Task<Response<IEnumerable<Layer>>> AddLayers(UserLayersDrawBoxIdRequest request)
        {
            return await _layerManager.AddAllAsync(request.layers);
        }
        //Buna Tekrar Bak List<int> olmalı
        [HttpDelete("layers/delete")]
        public async Task<Response<NoDataDto>> DeleteLayers(UserLayersDrawBoxIdRequest request)
        {
            return await _layerManager.DeleteAllAsync(request.layers);
        }

        [HttpPut("layers/update")]
        public async Task<Response<NoDataDto>> UpdateLayers(UserLayersDrawBoxIdRequest request)
        {
            return await _layerManager.UpdateAllAsync(request.layers);
        }

        [HttpGet("layers/{id}")]
        public async Task<Response<Layer>> GetLayer(int id)
        {
            return await _layerManager.GetAsync(id);
        }

        [HttpGet("layers/layer/elements")]
        public async Task<Response<IEnumerable<Element>>> GetElements(UserLayerDrawBoxIdRequest request)
        {
            return await _layerManager.GetElementsAsync(request.userLayerId);
        }

        [HttpGet("layers/layer/pen")]
        public async Task<Response<Pen>> GetPen(UserLayerDrawBoxIdRequest request)
        {
            return await _layerManager.GetPenAsync(request.userLayerId);
        }

        
    }
}
