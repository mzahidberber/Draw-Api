using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IDrawBoxService
    {
        object GetAll(User user);
        object Get(User user, int drawId);
        object GetLayers(User user, int drawId);
        object AddAll(User user,List<DrawBox> entities);
        object UpdateAll(User user,  List<DrawBox> entities);
        object DeleteAll(User user,List<DrawBox> entities);
    }
}
