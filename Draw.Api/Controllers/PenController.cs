using Draw.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PenController:ControllerBase
    {
        [HttpPost("pens")]
        public object GetPens(string userName)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.GetPens(userName);
            return result;
        }
    }
}
