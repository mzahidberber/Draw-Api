using Draw.Business.Abstract.BaseSevice;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IPointService:IBaseService<User, Point>
    {
        object? GetElement(User user, int entityId);
        object? GetPointType(User user, int entityId);
    }
}
