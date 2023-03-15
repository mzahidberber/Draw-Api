using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.DrawElements;
using Draw.DrawLayer.Concrete.Elements;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Abstract
{
    public interface IBaseCommand
    {
        Task<Element> AddPointAsync(PointD point);
        void FinishCommand();
    }
}
