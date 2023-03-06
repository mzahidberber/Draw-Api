using Draw.DataAccess.Abstract.Draws;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Draw;

namespace Draw.DataAccess.Concrete.EntityFramework.Draws
{
    public class EfDrawBoxDal:EfEntityRepositoryBase<DrawBox>,IDrawBoxDal
    {
    }
}
