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
    public class ColorController: ControllerBase
    {
        private IColorService _colorManager;

        public ColorController()
        {
            _colorManager = InstanceFactory.GetInstance<IColorService>();
        }
        [HttpGet("colors")]
        public object GetColors(User user)
        {
            return _colorManager.GetAll(user);
        }

        [HttpGet("colors/color")]
        public object? GetColor(UserColorIdRequest request)
        {
            return _colorManager.Get(request.user,u=>u.ColorId==request.colorId);
        }

        [HttpPost("colors/add")]
        public object AddColors(UserColorsRequest request)
        {
            return _colorManager.AddAll(request.user, request.colors);
        }

        [HttpDelete("colors/delete")]
        public object DeleteColors(UserColorsRequest request)
        {
            return _colorManager.DeleteAll(request.user, request.colors);
        }

        [HttpPut("colors/update")]
        public object UpdateColors(UserColorsRequest request)
        {
            return _colorManager.UpdateAll(request.user, request.colors);
        }

    }
}
