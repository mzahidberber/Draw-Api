using Draw.Api.Models.LayerRequest;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LayerController:ControllerBase
    {
        private ILayerService _layerManager;

        public LayerController()
        {
            _layerManager = InstanceFactory.GetInstance<ILayerService>();
        }
        
        [HttpGet("layers")]
        public object GetLayers(UserDrawBoxIdRequest request)
        {
            return _layerManager.GetAll(request.user, request.userDrawBoxId);
        }

        [HttpPost("layers/add")]
        public object AddLayers(UserLayersDrawBoxIdRequest request)
        {
            return _layerManager.AddAll(request.user, request.userDrawBoxId,request.layers);
        }

        [HttpDelete("layers/delete")]
        public object DeleteLayers(UserLayersDrawBoxIdRequest request)
        {
            return _layerManager.DeleteAll(request.user, request.userDrawBoxId, request.layers);
        }

        [HttpPut("layers/update")]
        public object UpdateLayers(UserLayersDrawBoxIdRequest request)
        {
            return _layerManager.UpdateAll(request.user, request.userDrawBoxId, request.layers);
        }

        [HttpGet("layers/layer")]
        public object GetLayer(UserLayerDrawBoxIdRequest request)
        {
            return _layerManager.Get(request.user, request.userDrawBoxId,request.userLayerId);
        }

        [HttpGet("layers/layer/elements")]
        public object GetElements(UserLayerDrawBoxIdRequest request)
        {
            return _layerManager.GetElements(request.user, request.userDrawBoxId, request.userLayerId);
        }

        [HttpGet("layers/layer/pen")]
        public object GetPen(UserLayerDrawBoxIdRequest request)
        {
            return _layerManager.GetPen(request.user, request.userDrawBoxId, request.userLayerId);
        }

        
    }
}
