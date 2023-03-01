using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract.BaseSevice
{
    public interface IHelperService<U, E>
        where U : class, IEntity, new()
        where E : class, IEntity, new()
    {
        object GetAll(U user);
        object Get(U user, int entityId);
        object AddAll(U user, List<E> entities);
        object UpdateAll(U user, List<E> entities);
        object DeleteAll(U user, List<E> entities);
    }
}
