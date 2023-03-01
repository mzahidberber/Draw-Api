using Draw.Api.Models.ColorRequest;
using Draw.Api.Models.PenStyleRequest;
using Draw.Business.Abstract;
using Draw.Business.Concrete;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Users;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PenStylesController : ControllerBase
    {

        private IPenStyleService _penStyleManager;

        public PenStylesController()
        {
            _penStyleManager = InstanceFactory.GetInstance<IPenStyleService>();
        }
        [HttpGet("penstyles")]
        public object GetPenStyles(User user)
        {
            return _penStyleManager.GetAll(user);
        }

        [HttpGet("penstyles/penstyle")]
        public object GetPenStyle(UserPenStyleIdRequest request)
        {
            return _penStyleManager.Get(request.user, request.penstyleId);
        }

        [HttpPost("penstyles/add")]
        public object AddPenStyles(UserPenStyleRequest request)
        {
            return _penStyleManager.AddAll(request.user,request.penstyles);
        }

        [HttpDelete("penstyles/delete")]
        public object DeletePenStyles(UserPenStyleRequest request)
        {
            return _penStyleManager.DeleteAll(request.user, request.penstyles);
        }

        [HttpPut("penstyles/update")]
        public object UpdatePenStyles(UserPenStyleRequest request)
        {
            return _penStyleManager.UpdateAll(request.user, request.penstyles);
        }
    }
}
