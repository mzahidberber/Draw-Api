using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IElementService
    {
        object GetAll(User user, int drawId,int layerId);
        object Get(User user, int drawId, int layerId, int entityId);
        object AddAll(User user, int drawId, int layerId, List<Element> entities);
        object UpdateAll(User user, int drawId, int layerId, List<Element> entities);
        object DeleteAll(User user, int drawId, int layerId, List<Element> entities);
        object GetPen(User user, int drawId, int layerId, int entityId);
        object GetElementType(User user, int drawId, int layerId, int entityId);
        object GetLayer(User user, int drawId, int layerId, int entityId);
        object GetRadiuses(User user, int drawId, int layerId, int entityId);
        object GetSSAngles(User user, int drawId, int layerId, int entityId);
        object GetPoints(User user, int drawId, int layerId, int entityId);
        
    }
}
