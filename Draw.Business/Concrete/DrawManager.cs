using Draw.Business.Abstract;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.DrawElements;

namespace Draw.Business.Concrete
{
    public class DrawManager:IDrawService
    {

        public object AddCoordinates(MouseInformation mouseInformation, string userName)
        {
            return "";
        }
        
        public object StartCommand(CommandEnums command,string userName,int userDrawBoxId,int userLayerId)
        {
            return "";
        }
        


    }

    
}
