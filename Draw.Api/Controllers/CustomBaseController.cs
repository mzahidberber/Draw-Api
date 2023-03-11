using Draw.Business.Abstract;
using Draw.Business.Abstract.BaseSevice;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Draw.Api.Controllers
{
    
    public class CustomBaseController:ControllerBase
    {

        protected IColorService _colorManager;
        protected ILayerService _layerManager;
        protected IDrawBoxService _drawBoxManager;
        protected IElementService _elementManager;
        public CustomBaseController()
        {
            _colorManager = InstanceFactory.GetInstance<IColorService>();
            _layerManager = InstanceFactory.GetInstance<ILayerService>();
            _drawBoxManager = InstanceFactory.GetInstance<IDrawBoxService>();
            _elementManager = InstanceFactory.GetInstance<IElementService>();
        }
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

        protected string GetUserId(ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return id ?? throw new CustomException("User id not found");
        }


    }
}
