using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfElementTypeDal : EfEntityRepositoryBaseAbstract<ElementType>, IElementTypeDal
    {
        public EfElementTypeDal(DrawContext context) : base(context)
        {
        }


    }
}
