using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Abstract
{
    public interface IDrawAdminastor
    {
        CommandData _commandData { get; set; }
        Task StartCommandAsync(CommandEnums commandEnum, int? DrawBoxId, int? LayerId, int? PenId);
        Task<ElementInformation> AddCoordinateAdminastorAsync(PointD point);
        Task SetRadiusAsync(double radius);
        Task SetEditElementsIdAsync(List<int> editElementsId);
        Task StopCommandAsync();
        Task<MemoryStream> SaveDraw(DrawBox drawBox);
        Task<DrawBox> ReadDraw(Stream drawFile);
    }
}
