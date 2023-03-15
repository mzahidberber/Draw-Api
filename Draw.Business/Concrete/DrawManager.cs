using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Elements;

namespace Draw.Business.Concrete
{
    public class DrawManager : IDrawService
    {
        public async Task<Response<NoDataDto>> StartCommand(string userId, CommandEnums command, int DrawBoxId, int LayerId, int penId)
        {
            //id leri kontrol et
            var drawAdminastor = DrawAdminastorMultiton.GetDrawAdminastor(userId);
            await drawAdminastor.StartCommandAsync(command,DrawBoxId,LayerId,penId);
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<NoDataDto>> StopCommand(string userId)
        {
            var drawAdminastor = DrawAdminastorMultiton.GetDrawAdminastor(userId);
            await drawAdminastor.StopCommandAsync();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<Response<ElementDTO>> AddCoordinate(string userId, PointD point)
        {
            var drawAdminastor = DrawAdminastorMultiton.GetDrawAdminastor(userId);
            var data= await drawAdminastor.AddCoordinateAdminastorAsync(point);
            return Response<ElementDTO>.Success(ObjectMapper.Mapper.Map<ElementDTO>(data),200);
        }
    }


}
