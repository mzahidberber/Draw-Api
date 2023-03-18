using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Model;

namespace Draw.DrawLayer.Abstract
{
    public interface IDrawAdminastor
    {
        Task StartCommandAsync(CommandEnums commandEnum, int DrawBoxId, int LayerId, int PenId);
        Task<ElementInformation> AddCoordinateAdminastorAsync(PointD point);
        Task SetRadiusAsync(double radius);
        Task SetEditElementsIdAsync(List<int> editElementsId);
        Task StopCommandAsync();
    }
}
