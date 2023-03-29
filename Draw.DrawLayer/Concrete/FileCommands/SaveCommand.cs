using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.FileCommands
{
    public class SaveCommand
    {
        private IElementDal _elementDal;
        public SaveCommand()
        {
            _elementDal=DataInstanceFactory.GetInstance<IElementDal>();
        }
        public static async Task SaveElementsAsync(List<Element> elements)
        {
            IElementDal _elementDal = DataInstanceFactory.GetInstance<IElementDal>();
            //element daha öncdn varmı kontrol et
            foreach (var element in elements)
            {
                await _elementDal.AddAsync(element);
            }
            await _elementDal.CommitAsync();
        }
    }
}
