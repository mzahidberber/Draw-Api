using Draw.Api.Models.PenStyleRequest;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Users;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointTypeController: ControllerBase
    {
        private IPointTypeService _pointTypeService;

        public PointTypeController()
        {
            _pointTypeService = InstanceFactory.GetInstance<IPointTypeService>();
        }
        [HttpGet("pointTypes")]
        public object GetPointTypes(User user)
        {
            return _pointTypeService.GetAll(user);
        }

        [HttpGet("pointTypes/pointType")]
        public object GetPointType(UserPointTypeIdRequest request)
        {
            return _pointTypeService.Get(request.user, request.pointTypeId);
        }

        [HttpPost("pointTypes/add")]
        public object AddPointTypes(UserPointTypeRequest request)
        {
            return _pointTypeService.AddAll(request.user, request.pointTypes);
        }

        [HttpDelete("pointTypes/delete")]
        public object DeletePointTypes(UserPointTypeRequest request)
        {
            return _pointTypeService.DeleteAll(request.user, request.pointTypes);
        }

        [HttpPut("pointTypes/update")]
        public object UpdatePointTypes(UserPointTypeRequest request)
        {
            return _pointTypeService.UpdateAll(request.user, request.pointTypes);
        }
    }
}
