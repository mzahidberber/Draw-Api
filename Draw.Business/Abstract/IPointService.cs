using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IPointService
    {
        object GetAll(User user, int drawId, int layerId,int elementId);
        object Get(User user, int drawId, int layerId, int elementId, int entityId);
        object AddAll(User user, int drawId, int layerId, int elementId, List<Point> entities);
        object UpdateAll(User user, int drawId, int layerId, int elementId, List<Point> entities);
        object DeleteAll(User user, int drawId, int layerId, int elementId, List<Point> entities);
        object GetElement(User user, int drawId, int layerId, int elementId, int entityId);
        object GetPointType(User user, int drawId, int layerId, int elementId, int entityId);
    }
}
