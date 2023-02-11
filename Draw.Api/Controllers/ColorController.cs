using Draw.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController: ControllerBase
    {
        [HttpPost("colors")]
        public object GetColors(string userName)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.GetColors(userName);
            return result;
        }
    }
}
