using Draw.Business.Concrete;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Manager.Concrete.DrawElements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DrawController : ControllerBase
    {
        private DrawBusinessManager _drawBusinessManager = DrawBusinessManager.CreateDrawBusinessManager();

        [HttpPost("startCommand")]
        public object startCommand([FromBody] CommandEnums command, string userName, int userDrawBoxId, int userLayerId)
        {
            var result = _drawBusinessManager.StartCommand(command, userName, userDrawBoxId, userLayerId);
            return result;
        }

        [HttpPost("mousePosition")]
        public object mousePosition([FromBody] MouseInformation mouseInformation, string userName)
        {
            var result = _drawBusinessManager.AddCoordinates(mouseInformation, userName);
            Console.WriteLine(result);
            return result;
        }



    }





}
