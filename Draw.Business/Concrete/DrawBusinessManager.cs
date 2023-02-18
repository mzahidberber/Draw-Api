using Draw.Business.Abstract;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Entities.Concrete.Elements;
using Draw.Manager.Concrete.DrawElements;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Draw.Business.Concrete
{
    public class DrawBusinessManager:DrawServiceAbstract
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
        public static object AddCoordinates(MouseInformation mouseInformation, string userName)
        {
            //if (UserManager.IsStartCommandUser(userName) == true)
            //{
            //    return UserManager.GetLogginUserDrawManager(userName).AddCoordinate(mouseInformation);
            //}
            //return "önce komut baslat";
            return UserManager.GetLogginUserDrawManager(userName).AddCoordinate(mouseInformation);
        }
        
        public static object StartCommand(CommandEnums command,string userName,int userDrawBoxId,int userLayerId)
        {
            //if (UserManager.IsStartCommandUser(userName) == false)
            //{
            //    UserManager.StartCommandUser(userName);
            //    return UserManager.GetLogginUserDrawManager(userName).StartCommand(command,userDrawBoxId,userLayerId,1);
            //}
            //return "zaten komut başladı";
            return UserManager.GetLogginUserDrawManager(userName).StartCommand(command, userDrawBoxId, userLayerId, 1);
        }

        public static object GetLayers(string userName, int userDrawBoxId)
        {
            return UserManager.GetLogginUserDrawManager(userName).GetLayers(userDrawBoxId);
        }

        public static object GetDrawBoxes(string userName)
        {
            return UserManager.GetLogginUserDrawManager(userName).GetDrawBoxes();
        }

        public static object GetColors(string userName)
        {
            return UserManager.GetLogginUserDrawManager(userName).GetColors();
        }
        public static object GetPenStyles(string userName)
        {
            return UserManager.GetLogginUserDrawManager(userName).GetPenStyles();
        }

        public static object GetPens(string userName)
        {
            return UserManager.GetLogginUserDrawManager(userName).GetPens();
        }

        public static object GetElements(string userName,int drawBoxId)
        {
            return UserManager.GetLogginUserDrawManager(userName).GetElements(drawBoxId);
        }



    }
}
