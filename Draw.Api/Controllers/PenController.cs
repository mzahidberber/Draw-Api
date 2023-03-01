using Draw.Api.Models.PenRequest;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PenController:ControllerBase
    {
        private IPenService _penManager;

        public PenController()
        {
            _penManager = InstanceFactory.GetInstance<IPenService>();
        }

        [HttpGet("pens")]
        public object GetPens(UserPenRequest request)
        {
            return _penManager.GetAll(request.user, request.drawId, request.layerId);
        }
        
        [HttpGet("pens/pen")]
        public object GetPens(UserPenIdRequest request)
        {
            return _penManager.Get(request.user, request.drawId, request.layerId,request.penId);
        }

        [HttpGet("pens/pen/color")]
        public object GetPenAtColor(UserPenIdRequest request)
        {
            return _penManager.GetColor(request.user, request.drawId, request.layerId, request.penId);
        }

        [HttpGet("pens/pen/penstyle")]
        public object GetPenAtPenStyle(UserPenIdRequest request)
        {
            return _penManager.GetPenStyle(request.user, request.drawId, request.layerId, request.penId);
        }


        [HttpPost("pens/add")]
        public object AddPens(UserPensDLRequest request)
        {
            return _penManager.AddAll(request.user,request.drawId,request.layerId ,request.pens);
        }

        [HttpDelete("pens/delete")]
        public object DeletePens(UserPensDLRequest request)
        {
            return _penManager.DeleteAll(request.user, request.drawId, request.layerId, request.pens);
        }

        [HttpPut("pens/update")]
        public object UpdatePens(UserPensDLRequest request)
        {
            return _penManager.UpdateAll(request.user, request.drawId, request.layerId, request.pens);
        }

    }
}
