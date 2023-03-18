using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Abstract
{
    public interface IBaseCommand
    {
        Task<ElementInformation> AddPointAsync(PointD point);
        void FinishCommand();
    }
}
