using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Elements;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Abstract
{
    public interface IDrawAdminastor
    {
        Task StartCommandAsync(CommandEnums commandEnum, int DrawBoxId, int LayerId, int PenId);
        Task<Element> AddCoordinateAdminastorAsync(PointD point);
        void SetRadius(double radius);
        void SetEditElementsId(List<int> editElementsId);
        Task StopCommandAsync();
    }
}
