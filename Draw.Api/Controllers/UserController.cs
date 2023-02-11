using Draw.Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        [HttpPost("register/")]
        public string register(string userName,string password)
        {
            UserManager.CreateUserManager();
            var result = UserManager.RegisterUser(userName,password);
            return result;
        }

        [HttpPost("login/")]
        public object login(string username, string password)
        {
            UserManager.CreateUserManager();
            var result = UserManager.Login(username,password);
            return result;
        }

        [HttpPost("logout/")]
        public object logout(string username, string password)
        {
            UserManager.CreateUserManager();
            var result = UserManager.LogOut(username,password);
            return result;
        }
    }
}
