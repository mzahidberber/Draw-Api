using Draw.Api.Models.ElementRequest;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElementController:ControllerBase
    {
        private IElementService _elementManager;
        public ElementController()
        {
            _elementManager=InstanceFactory.GetInstance<IElementService>();
        }
        [HttpGet("elements")]
        public object GetElements(UserElementRequest request)
        {
            return _elementManager.GetAll(request.user, request.drawId,request.layerId);
        }

        [HttpPost("elements/add")]
        public object AddElements(UserDLElementsRequest request)
        {
            return _elementManager.AddAll(request.user, request.drawId, request.layerId, request.elements);
        }

        [HttpDelete("elements/delete")]
        public object DeleteElements(UserDLElementsRequest request)
        {
            return _elementManager.DeleteAll(request.user, request.drawId, request.layerId, request.elements);
        }

        [HttpPut("elements/update")]
        public object UpdateElements(UserDLElementsRequest request)
        {
            return _elementManager.UpdateAll(request.user, request.drawId, request.layerId, request.elements);
        }

        [HttpGet("elements/element")]
        public object GetElement(UserDLElementRequest request)
        {
            return _elementManager.Get(request.user, request.drawId, request.layerId,request.elementId);
        }

        [HttpGet("elements/element/elementType")]
        public object GetElementType(UserDLElementRequest request)
        {
            return _elementManager.GetElementType(request.user, request.drawId, request.layerId, request.elementId);
        }

        [HttpGet("elements/element/pen")]
        public object GetPen(UserDLElementRequest request)
        {
            return _elementManager.GetPen(request.user, request.drawId, request.layerId, request.elementId);
        }

        [HttpGet("elements/element/layer")]
        public object GetLayer(UserDLElementRequest request)
        {
            return _elementManager.GetLayer(request.user, request.drawId, request.layerId, request.elementId);
        }
        [HttpGet("elements/element/radiuses")]
        public object GetRadiuses(UserDLElementRequest request)
        {
            return _elementManager.GetRadiuses(request.user, request.drawId, request.layerId, request.elementId);
        }

        [HttpGet("elements/element/ssangles")]
        public object GetSSAngles(UserDLElementRequest request)
        {
            return _elementManager.GetSSAngles(request.user, request.drawId, request.layerId, request.elementId);
        }
        
        [HttpGet("elements/element/points")]
        public object GetPoints(UserDLElementRequest request)
        {
            return _elementManager.GetPoints(request.user, request.drawId, request.layerId, request.elementId);
        }


    }
}
