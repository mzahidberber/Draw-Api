using Draw.Core.DTOs;
using Draw.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;

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
    }
}
