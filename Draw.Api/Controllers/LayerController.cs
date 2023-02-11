using Draw.Business.Concrete;
using Draw.DrawManager.Concrete.BaseCommand;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LayerController:ControllerBase
    {
        [HttpPost("layers")]
        public object getLayers(string userName,int userDrawBoxId)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.GetLayers(userName, userDrawBoxId);
            return result;
        }
    }
}
