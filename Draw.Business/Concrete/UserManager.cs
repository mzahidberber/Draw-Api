using Draw.DataAccess.Concrete.EntityFramework.Users;
using Draw.DrawManager.Models;
using Draw.Entities.Concrete.Users;
using Draw.DrawManager.Concrete;
using Draw.Business.Abstract;

namespace Draw.Business.Concrete
{
    public class UserManager:IUserService
    {
        private static UserManager? _userManager;
        static object _lockObject = new object();
        public static UserManager CreateUserManager()
        {
            lock (_lockObject)
            {
                if (_userManager == null)
                {
                    _userManager = new UserManager();
                }
            }
            return _userManager;
        }

        private static EfUserDal _userDal = new EfUserDal();
        //private static EfUserDal __userdal=Instance
        private static List<UserInformation> _loginUsers= new List<UserInformation>();

        public static DrawM GetLogginUserDrawManager(string username)
        {
            return _loginUsers.Where(u => u.UserName == username).Select(u => u.DrawManager).Single();
        }
        public static void AddLoginUser(string userName)
        {
            if (UserNameDataControl(userName) != null)
            {
                if (!_loginUsers.Any(u => u.UserName == userName))
                {
                    _loginUsers.Add(new UserInformation(userName, false, null, null,new DrawM (userName)));
                    Console.WriteLine($"Giriş Yapan Kullanıcılara {userName} eklendi");
                }
                else
                {
                    Console.WriteLine("Zaten giriş yapılmış");
                }
            }
            else
            {
                Console.WriteLine("Böyle bir kullanıcı yok");
            }
        }

        public static void RemoveLoginUser(string userName)
        {
            if (_loginUsers.Any(u => u.UserName == userName))
            {
                _loginUsers.Remove(_loginUsers.Where(u => u.UserName == userName).Single());
                Console.WriteLine($"{userName} Çıkış yaptı!!");
            }
            else
            {
                Console.WriteLine("Böyle bir kullanıcı yok");
            }
        }

        public static List<UserInformation> GetLoginUsers() { return _loginUsers; }


        public static object Login(string username, string password)
        {
            var user = _userDal.Get(u => u.UserName == username && u.UserPassword == password);
            
            if (user != null && _loginUsers!=null && !_loginUsers.Any(u=>u.UserName==username))
            {
                AddLoginUser(username);
                LoginInformation result = new LoginInformation { login=true};
                return result;
            }

            return "Bilgiler yanlış veya daha önce giriş yapılmış";
        }

        public static object LogOut(string username,string password)
        {
            
            var logoutuser=_loginUsers.Where(u => u.UserName == username).SingleOrDefault();
            if (logoutuser!=null)
            {
                RemoveLoginUser(logoutuser.UserName);
                string result = "LogOut : " + logoutuser.UserName;
                return result;
            }

            return "Önce Giriş Yapılmalı";
        }

        public static string RegisterUser(string username,string password)
        {
            var userControl=_userDal.Get(u=>u.UserName== username);
            if (userControl == null)
            {
                User newUser = new User { UserName = username, UserPassword = password };
                _userDal.Add(newUser);
                return "Kayit Başarılı";
            }
            return "Kayit Başarısız";
        }
        internal static void StartCommandUser(string username)
        {
            if (_loginUsers.Any(u=>u.UserName==username))
            {
                _loginUsers.Where(u=>u.UserName==username).Single().IsStartCommand = true;
            }
        }
        internal static void StopCommandUser(string username)
        {
            if (_loginUsers.Any(u => u.UserName == username))
            {
                _loginUsers.Where(u => u.UserName == username).Single().IsStartCommand = false;
            }
        }
        internal static bool IsStartCommandUser(string userName)
        {
            foreach (var item in _loginUsers)
            {
                Console.WriteLine(item.UserName);
            }
            return IsLoggedUser(userName) ? _loginUsers.Where(u => u.UserName == userName).Single().IsStartCommand : false;
        }

        internal static bool IsLoggedUser(string userName)
        {
            var loggedUser = _loginUsers.Where(u => u.UserName == userName);
            return loggedUser == null ? false : true;
        }

        private static User? UserNameDataControl(string userName)
        {
            return _userDal.IsUserName(userName);
        }

        private static User? UserIdDataControl(User user)
        {
            return _userDal.IsUserId(user);
        }
    }

    public class LoginInformation
    {
        public bool login { get; set; }
    }
}
