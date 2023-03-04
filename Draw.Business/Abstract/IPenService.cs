using Draw.Business.Abstract.BaseSevice;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IPenService:IBaseService<User, Pen>
    {
        object? GetColor(User user, int penId);
        object? GetPenStyle(User user, int penId);
    }
}
