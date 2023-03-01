using Draw.Core.Business.Abstract;
using Draw.Entities.Abstract;

namespace Draw.Core.Business.Concrete
{
    public abstract class LoginAbstract<T> : ILoginController<T> where T : class, IEntity, new()
    {
        public virtual bool IsLoggedIn(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
