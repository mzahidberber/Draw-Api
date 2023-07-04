using Draw.Core.DrawLayer.Abstract;
using Draw.Core.DrawLayer.Model;
using Draw.Entities.Concrete.Draw;

namespace Draw.Core.DrawLayer.Abstract
{
    public interface IDrawAdminastor
    {
        ICommandData _commandData { get; set; }
        Task StartCommandAsync(CommandEnums commandEnum, int? DrawBoxId, int? LayerId, int? PenId);
        Task<ElementInformation> AddCoordinateAdminastorAsync(PointD point);
        Task SetRadiusAsync(double radius);
        Task SetEditElementsIdAsync(List<int> editElementsId);
        Task StopCommandAsync();
        Task<MemoryStream> SaveDraw(DrawBox drawBox);
        Task<DrawBox> ReadDraw(Stream drawFile);
    }
}
