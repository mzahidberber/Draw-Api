using Draw.Business.Concrete;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Manager.Concrete.DrawElements;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrawController : ControllerBase
    {
        

        [HttpPost ("startCommand")]
        public object startCommand([FromBody] CommandEnums command,string userName,int userDrawBoxId,int userLayerId)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result = DrawBusinessManager.StartCommand(command,userName,userDrawBoxId,userLayerId);
            return result;
        }

        [HttpPost ("mousePosition/")]
        public object mousePosition([FromBody]MouseInformation mouseInformation,string userName)
        {
            DrawBusinessManager.CreateDrawBusinessManager();
            var result= DrawBusinessManager.AddCoordinates(mouseInformation, userName);
            Console.WriteLine(result);
            return result;
        }
        
        

    }


    
    
    
}
