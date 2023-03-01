using Draw.Entities.Concrete.Users;

namespace Draw.Core.Business.Concrete
{
    public class UserLogin:LoginAbstract<User>
    {

        public override bool IsLoggedIn(User entity)
        {
            return base.IsLoggedIn(entity);
        }
    }
}
