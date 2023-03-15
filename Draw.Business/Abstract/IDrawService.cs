using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Elements;

namespace Draw.Business.Abstract
{
    public interface IDrawService
    {
        Task<Response<ElementDTO>> AddCoordinate(string userId,PointD point);
        Task<Response<NoDataDto>> StartCommand(string userId,CommandEnums command, int DrawBoxId, int LayerId, int penId);
        Task<Response<NoDataDto>> StopCommand(string userId);
    }
}
