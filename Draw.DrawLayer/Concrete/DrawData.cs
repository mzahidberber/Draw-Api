using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete
{
    public class DrawData
    {
        private IElementDal _efElementDal;

        public DrawData()
        {
            _efElementDal= DataInstanceFactory.GetInstance<IElementDal>();
        }
        public async Task AddElementAsync(Element element)
        {
            _efElementDal = DataInstanceFactory.GetInstance<IElementDal>();
            await _efElementDal.AddAsync(element);
            await _efElementDal.CommitAsync();
        }
    }
}
