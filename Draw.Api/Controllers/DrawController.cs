using Draw.Business.Concrete;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.DrawElements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DrawController : CustomBaseController
    {

        [HttpPost("startCommand")]
        public async Task<IActionResult> startCommand([FromBody] CommandEnums command, string userName, int userDrawBoxId, int userLayerId)
        {
            //var result = _drawBusinessManager.StartCommand(command, userName, userDrawBoxId, userLayerId);
            return ActionResultInstance();
        }

        [HttpPost("mousePosition")]
        public object mousePosition([FromBody] MouseInformation mouseInformation, string userName)
        {
            //var result = _drawBusinessManager.AddCoordinates(mouseInformation, userName);
            Console.WriteLine(result);
            return result;
        }



    }





}
