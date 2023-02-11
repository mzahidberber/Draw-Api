using Draw.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ElementController:ControllerBase
    {
        [HttpPost("getElementsWithItsLayer")]
        public object getElementsWithItsLayer(string userName,int drawBoxId)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.GetElements(userName,drawBoxId);
            return result;
        }
    }
}
