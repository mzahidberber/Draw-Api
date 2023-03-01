using Draw.Business.Abstract;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class PenManager : IPenService
    {
        public object AddAll(User user, int drawId, int layerId, List<Pen> pens)
        {
            throw new NotImplementedException();
        }

        public object DeleteAll(User user, int drawId, int layerId, List<Pen> pens)
        {
            throw new NotImplementedException();
        }

        public object Get(User user, int drawId, int layerId, int penId)
        {
            throw new NotImplementedException();
        }

        public object GetAll(User user, int drawId, int layerId)
        {
            throw new NotImplementedException();
        }

        public object GetColor(User user, int drawId, int layerId, int penId)
        {
            throw new NotImplementedException();
        }

        public object GetPenStyle(User user, int drawId, int layerId, int penId)
        {
            throw new NotImplementedException();
        }

        public object UpdateAll(User user, int drawId, int layerId, List<Pen> pens)
        {
            throw new NotImplementedException();
        }
    }
}
