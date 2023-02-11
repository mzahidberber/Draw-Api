using Draw.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PenStylesController : ControllerBase
    {
        [HttpPost("penstyles")]
        public object GetPenStyles(string userName)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.GetPenStyles(userName);
            return result;
        }
    }
}
