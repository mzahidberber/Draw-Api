using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Manager.Concrete.DrawElements;

namespace Draw.Business.Concrete
{
    public class DrawBusinessManager
    {
        private static DrawBusinessManager? _drawBaseManager;
        static object _lockObject = new object();
        private DrawBusinessManager() { }
        public static DrawBusinessManager CreateDrawBusinessManager()
        {
            lock (_lockObject)
            {
                if (_drawBaseManager == null)
                {
                    _drawBaseManager = new DrawBusinessManager();
                }

            }
            return _drawBaseManager;
        }

        private UserManager1 _userManager = UserManager1.CreateUserManager();

        public object AddCoordinates(MouseInformation mouseInformation, string userName)
        {
            return "";
            //return _userManager.GetLogginUserDrawManager(userName).AddCoordinate(mouseInformation);
        }
        
        public object StartCommand(CommandEnums command,string userName,int userDrawBoxId,int userLayerId)
        {
            return "";
            //return _userManager.GetLogginUserDrawManager(userName).StartCommand(command, userDrawBoxId, userLayerId, 1);
        }
        


    }

    
}
