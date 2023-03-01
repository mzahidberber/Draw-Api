

using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IUserService
    {
        object Login(User user);
        object Logout(User user);
        object Register(User user);
    }
}