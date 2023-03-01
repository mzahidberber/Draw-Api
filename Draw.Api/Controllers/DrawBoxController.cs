using Draw.Api.Models.DrawBoxRequest;
using Draw.Api.Models.LayerRequest;
using Draw.Business.Abstract;
using Draw.Business.Concrete;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Users;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrawBoxController:ControllerBase
    {
        private IDrawBoxService _drawBoxManager;
        public DrawBoxController()
        {
            _drawBoxManager=InstanceFactory.GetInstance<IDrawBoxService>();
        }
        [HttpGet("drawBoxes")]
        public object GetDrawBoxes(User user)
        {
            return _drawBoxManager.GetAll(user);
        }

        [HttpPost("drawBoxes/add")]
        public object AddDrawBoxes(UserDrawBoxesRequest request)
        {
            return _drawBoxManager.AddAll(request.user, request.drawBoxes);
        }

        [HttpDelete("drawBoxes/delete")]
        public object DeleteDrawBoxes(UserDrawBoxesRequest request)
        {
            return _drawBoxManager.DeleteAll(request.user, request.drawBoxes);
        }

        [HttpPut("drawBoxes/update")]
        public object UpdateDrawBoxes(UserDrawBoxesRequest request)
        {
            return _drawBoxManager.UpdateAll(request.user, request.drawBoxes);
        }

        [HttpGet("drawBoxes/drawBox")]
        public object GetDrawBox(UserDrawBoxRequest request)
        {
            return _drawBoxManager.Get(request.user, request.drawBoxId);
        }

        [HttpGet("drawBoxes/drawBox/layers")]
        public object GetLayers(UserDrawBoxRequest request)
        {
            return _drawBoxManager.GetLayers(request.user, request.drawBoxId);
        }

    }
}
