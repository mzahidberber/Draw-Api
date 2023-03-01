using Draw.Api.Models.LayerRequest;
using Draw.Api.Models.PointRequest;
using Draw.Business.Abstract;
using Draw.Business.Concrete;
using Draw.Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointController: ControllerBase
    {
        private IPointService _pointManager;
        public PointController()
        {
            _pointManager=InstanceFactory.GetInstance<IPointService>();
        }

        [HttpGet("points")]
        public object GetLayers(UserElementPointsRequest request)
        {
            return _pointManager.GetAll(request.user, request.drawId,request.layerId,request.elementId);
        }

        [HttpPost("points/add")]
        public object AddPoints(UserDLEPointsRequest request)
        {
            return _pointManager.AddAll(request.user, request.drawId, request.layerId, request.elementId,request.points);
        }

        [HttpDelete("points/delete")]
        public object DeletePoints(UserDLEPointsRequest request)
        {
            return _pointManager.DeleteAll(request.user, request.drawId, request.layerId, request.elementId, request.points);
        }

        [HttpPut("points/update")]
        public object UpdatePoints(UserDLEPointsRequest request)
        {
            return _pointManager.UpdateAll(request.user, request.drawId, request.layerId, request.elementId, request.points);
        }

        [HttpGet("points/point")]
        public object GetLayer(UserDLEPointRequest request)
        {
            return _pointManager.Get(request.user, request.drawId, request.layerId, request.elementId, request.pointId);
        }

        [HttpGet("points/element")]
        public object GetElement(UserDLEPointRequest request)
        {
            return _pointManager.GetElement(request.user, request.drawId, request.layerId, request.elementId, request.pointId);
        }

        [HttpGet("points/pointType")]
        public object GetPointType(UserDLEPointRequest request)
        {
            return _pointManager.GetPointType(request.user, request.drawId, request.layerId, request.elementId, request.pointId);
        }
    }
}
