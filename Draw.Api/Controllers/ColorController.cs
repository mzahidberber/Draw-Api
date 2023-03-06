using Draw.Api.Models.ColorRequest;
using Draw.Business.Abstract;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
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
        public async Task<Response<IEnumerable<ColorDTO>>> GetColors()
        {
            return await _colorManager.GetAllAsync();
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
