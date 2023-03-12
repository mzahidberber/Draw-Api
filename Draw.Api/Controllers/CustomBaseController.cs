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
