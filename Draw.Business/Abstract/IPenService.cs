using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IPenService:IBaseService<PenDTO>
    {
        Task<Response<ColorDTO>> GetColorAsync(string userId, int penId);
        Task<Response<PenStyleDTO>> GetPenStyleAsync(string userId,int penId);
    }
}
