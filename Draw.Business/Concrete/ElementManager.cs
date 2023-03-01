using Draw.Business.Abstract;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class ElementManager : IElementService
    {
        public object AddAll(User user, int drawId, int layerId, List<Element> entities)
        {
            throw new NotImplementedException();
        }

        public object DeleteAll(User user, int drawId, int layerId, List<Element> entities)
        {
            throw new NotImplementedException();
        }

        public object Get(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetAll(User user, int drawId, int layerId)
        {
            throw new NotImplementedException();
        }

        public object GetElementType(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetLayer(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetPen(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetPoints(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetRadiuses(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetSSAngles(User user, int drawId, int layerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object UpdateAll(User user, int drawId, int layerId, List<Element> entities)
        {
            throw new NotImplementedException();
        }
    }
}
