using Draw.Business.Abstract;
using Draw.Business.Models;
using Draw.DataAccess.Concrete.EntityFramework.Users;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.DrawManager.Concrete;
using Draw.Entities.Concrete.Users;

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

        private UserManager() { }

        

        private EfUserDal _userDal = DataInstanceFactory.GetInstance<EfUserDal>();
        private List<UserInformation> _loginUsers= new List<UserInformation>();
        private List<string> _loginUserss= new List<string>();



        public DrawM GetLogginUserDrawManager(string username)
        {
            return _loginUsers.Where(u => u.UserName == username).Select(u => u.DrawManager).Single();
        }
        public void AddLoginUser(User user)
        {
            if (UserNameDataControl(user.UserName) != null)
            {
                if (!_loginUsers.Any(u => u.UserName == user.UserName))
                {
                    _loginUsers.Add(new UserInformation(user.UserName, false, null, null,new DrawM (user.UserName)));
                    _loginUserss.Add(user.UserName);
                    Console.WriteLine($"Giriş Yapan Kullanıcılara {user.UserName} eklendi");
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

        public void RemoveLoginUser(string userName)
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

        public List<UserInformation> GetLoginUsers() { return _loginUsers; }


        public object Login(User user)
        {
            var loginUser = _userDal.Get(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
            
            if (user != null && !_loginUsers.Any(u=>u.UserName==user.UserName))
            {
                AddLoginUser(user);
                LoginInformation result = new LoginInformation { login=true};
                return result;
            }
            return new Exception("Information false or user logged");
        }
        public object Logout(User user)
        {
            var logoutuser = _loginUsers.Where(u => u.UserName == user.UserName).SingleOrDefault();
            if (logoutuser != null)
            {
                RemoveLoginUser(logoutuser.UserName);
                string result = "LogOut : " + logoutuser.UserName;
                return result;
            }

            return new Exception("User Not Found");
        }

        public object Register(User user)
        {
            var userControl = _userDal.Get(u => u.UserName == user.UserName);
            if (userControl == null)
            {
                _userDal.Add(user);
                return "Register Success";
            }
            return new Exception("Register Unsuccess");


        }

        internal void StartCommandUser(string username)
        {
            if (_loginUsers.Any(u=>u.UserName==username))
            {
                _loginUsers.Where(u=>u.UserName==username).Single().IsStartCommand = true;
            }
        }
        internal void StopCommandUser(string username)
        {
            if (_loginUsers.Any(u => u.UserName == username))
            {
                _loginUsers.Where(u => u.UserName == username).Single().IsStartCommand = false;
            }
        }
        internal bool IsStartCommandUser(User user)
        {
            return IsLoggedUser(user) ? _loginUsers.Where(u => u.UserName ==user.UserName).Single().IsStartCommand : false;
        }

        public bool IsLoggedUser(User user)
        {
            return _loginUsers.Any(u => u.UserName == user.UserName);
        }

        internal User? UserNameDataControl(string userName)
        {
            return _userDal.IsUserName(userName);
        }

        internal User? UserIdDataControl(User user)
        {
            return _userDal.IsUserId(user);
        }

        
        
    }

    public class LoginInformation
    {
        public bool login { get; set; }
    }
}
