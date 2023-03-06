using Draw.Business.Abstract;
using Draw.DataAccess.Abstract.Elements;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;
using System.Linq.Expressions;

namespace Draw.Business.Concrete
{
    public class ElementManager : IElementService
    {
        IElementDal _elementDal;
        public ElementManager()
        {
            _elementDal=DataInstanceFactory.GetInstance<IElementDal>();
        }

        public void AddAll(User user, List<Element> entities)
        {
            foreach (var entity in entities)
            {
                _elementDal.Add(entity);
            }
        }

        public void DeleteAll(User user, List<Element> entities)
        {
            foreach (var entity in entities)
            {
                _elementDal.Delete(entity);
            }
        }

        public object? Get(User user, Expression<Func<Element, bool>> filter)
        {
            return _elementDal.Get(filter);
        }

        public object? GetAll(User user, Expression<Func<Element, bool>>? filter = null)
        {
            return _elementDal.GetAll(filter);
        }

        public object? GetElementType(User user, int entityId)
        {
            return _elementDal.Get(e=>e.ElementId==entityId)?.ElementType;
        }

        public object? GetLayer(User user, int entityId)
        {
            return _elementDal.Get(e => e.ElementId == entityId)?.Layer;
        }

        public object? GetPen(User user, int entityId)
        {
            return _elementDal.Get(e => e.ElementId == entityId)?.Pen;
        }

        public object? GetPoints(User user, int entityId)
        {
            return _elementDal.Get(e => e.ElementId == entityId)?.Points;
        }

        public object? GetRadiuses(User user, int entityId)
        {
            return _elementDal.Get(e => e.ElementId == entityId)?.Radiuses;
        }

        public object? GetSSAngles(User user, int entityId)
        {
            return _elementDal.Get(e => e.ElementId == entityId)?.SSAngles;
        }

        public void UpdateAll(User user, List<Element> entities)
        {
            foreach (var entity in entities)
            {
                _elementDal.Update(entity);
            }
        }
    }
}
