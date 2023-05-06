
using Draw.Api.Models;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.CrosCuttingConcers.Logging.Nlog;
using Draw.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Draw.Api.Controllers
{

    public class CustomBaseController:ControllerBase,ILog
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
        [NonAction]
        public UserInfo GetUserInfo(ClaimsPrincipal user)
        {
            var id = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var name = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            return new UserInfo { id=id,name=name} ?? throw new CustomException("User info not found");
        }
        [NonAction]
        public string GetUserName()
        {
            return GetUserInfo(User).name;
        }
        [NonAction]
        public string GetUserId()
        {
            return GetUserInfo(User).id;
        }




    }
}
