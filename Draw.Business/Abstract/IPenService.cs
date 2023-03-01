using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IPenService
    {
        object GetAll(User user, int drawId,int layerId);
        object Get(User user, int drawId, int layerId ,int penId);
        object GetColor(User user, int drawId, int layerId, int penId);
        object GetPenStyle(User user, int drawId, int layerId, int penId);
        object AddAll(User user, int drawId, int layerId, List<Pen> pens);
        object UpdateAll(User user, int drawId, int layerId, List<Pen> pens);
        object DeleteAll(User user, int drawId, int layerId, List<Pen> pens);
    }
}
