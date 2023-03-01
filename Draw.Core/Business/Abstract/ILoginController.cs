using Draw.Entities.Abstract;

namespace Draw.Core.Business.Abstract
{
    public interface ILoginController<T> where T :class,IEntity,new()
    {
        bool IsLoggedIn(T entity);
    }
}
