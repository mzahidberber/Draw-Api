using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Model;

namespace Draw.Business.Abstract
{
    public interface IDrawService
    {
        Task<Response<ElementDTO>> AddCoordinate(string userId,PointD point);
        Task<Response<NoDataDto>> StartCommand(string userId,CommandEnums command, int DrawBoxId, int LayerId, int penId);
        Task<Response<NoDataDto>> StopCommand(string userId);
        Task<Response<NoDataDto>> SetRadius(string userId, double radius);
        Task<Response<NoDataDto>> SetElementsId(string userId, List<int> editElementsId);
    }
}
