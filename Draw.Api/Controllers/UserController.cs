using Draw.Business.Abstract;
using Draw.Business.Concrete;
using Draw.Business.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Users;
using Microsoft.AspNetCore.Mvc;

namespace Draw.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private IUserService _userManager;
        public UserController()
        {
            _userManager= InstanceFactory.GetInstance<IUserService>();
        }
        
        [HttpPost("register")]
        public object register(User user)
        {
            return _userManager.Register(user);
        }

        [HttpPost("login")]
        public object login(User user)
        {
            return _userManager.Login(user);
        }

        [HttpPost("logout")]
        public object logout(User user)
        {
            return _userManager.Logout(user);
        }
    }
}
