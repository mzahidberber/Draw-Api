using Draw.Core.DrawLayer.Model;

namespace Draw.Core.DrawLayer.Abstract
{
    public interface IBaseCommand
    {
        Task<ElementInformation> ControlCommandAsync();
        Task<ElementInformation> AddPointAsync(PointD point);
        void FinishCommand();
    }
}
