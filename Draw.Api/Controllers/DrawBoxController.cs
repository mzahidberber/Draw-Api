using Draw.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrawBoxController:ControllerBase
    {
        [HttpPost("drawBoxes")]
        public object GetDrawBoxes(string userName)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.GetDrawBoxes(userName);
            return result;
        }
    }
}
