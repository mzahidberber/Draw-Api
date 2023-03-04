using Draw.Business.Abstract;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;
using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.DependencyResolvers.Ninject;
using System.Linq.Expressions;

namespace Draw.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager()
        {
            _colorDal = InstanceFactory.GetInstance<IColorDal>();
        }

        public void AddAll(User user, List<Color> entities)
        {
            foreach (var color in entities)
            {
                _colorDal.Add(color);
            }
        }

        public void DeleteAll(User user, List<Color> entities)
        {
            foreach (var color in entities)
            {
                _colorDal.Delete(color);
            }
        }

        public object? Get(User user, int entityId)
        {
            return _colorDal.Get(c=>c.ColorId==entityId);
        }

        public object? GetAll(User user)
        {
            return _colorDal.GetAll();
        }

        public void UpdateAll(User user, List<Color> entities)
        {
            foreach (var color in entities)
            {
                _colorDal.Update(color);
            }
        }
    }
}
