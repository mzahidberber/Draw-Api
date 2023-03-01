using Draw.Business.Abstract;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class PointManager : IPointService
    {
        public object AddAll(User user, int drawId, int layerId, int elementId, List<Point> entities)
        {
            throw new NotImplementedException();
        }

        public object DeleteAll(User user, int drawId, int layerId, int elementId, List<Point> entities)
        {
            throw new NotImplementedException();
        }

        public object Get(User user, int drawId, int layerId, int elementId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetAll(User user, int drawId, int layerId, int elementId)
        {
            throw new NotImplementedException();
        }

        public object GetElement(User user, int drawId, int layerId, int elementId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object GetPointType(User user, int drawId, int layerId, int elementId, int entityId)
        {
            throw new NotImplementedException();
        }

        public object UpdateAll(User user, int drawId, int layerId, int elementId, List<Point> entities)
        {
            throw new NotImplementedException();
        }
    }
}
