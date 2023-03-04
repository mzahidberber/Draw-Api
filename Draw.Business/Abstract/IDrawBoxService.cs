using Draw.Business.Abstract.BaseSevice;
using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IDrawBoxService:IBaseService<User,DrawBox>
    {
        object? GetLayers(User user, int drawId);
    }
}
