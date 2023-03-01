using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface ILayerService
    {
        object GetAll(User user,int drawId);
        object Get(User user, int drawId, int entityId);
        object GetElements(User user, int drawId, int entityId);
        object GetPen(User user, int drawId, int entityId);
        object AddAll(User user,int drawId,List<Layer> entities);
        object UpdateAll(User user, int drawId,List<Layer> entities);
        object DeleteAll(User user, int drawId,List<Layer> entities);
    }
}
