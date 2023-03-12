using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfDrawBoxDal : EfEntityRepositoryBase<DrawBox>, IDrawBoxDal
    {
        public EfDrawBoxDal(DrawContext context) : base(context)
        {
        }

        public Task<DrawBox> GetByIdWithLayersAsync(int id)
        {
            //Layerla birlikte döndür
            throw new NotImplementedException();
        }
    }
}
