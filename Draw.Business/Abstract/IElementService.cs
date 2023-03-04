using Draw.Business.Abstract.BaseSevice;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IElementService:IBaseService<User,Element>
    {
        object? GetPen(User user, int entityId);
        object? GetElementType(User user, int entityId);
        object? GetLayer(User user, int entityId);
        object? GetRadiuses(User user, int entityId);
        object? GetSSAngles(User user, int entityId);
        object? GetPoints(User user, int entityId);
        
    }
}
