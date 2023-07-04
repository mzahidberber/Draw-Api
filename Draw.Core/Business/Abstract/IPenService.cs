using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Core.Business.Abstract
{
    public interface IPenService:IBaseService<PenDTO>
    {
        Task<Response<IEnumerable<PenDTO>>> GetAllWithAttAsync(string userId);
        //Task<Response<ColorDTO>> GetColorAsync(string userId, int penId);
        Task<Response<PenStyleDTO>> GetPenStyleAsync(string userId,int penId);
        Task<Response<IEnumerable<PenDTO>>> AddAllAttAsync(string userId, List<PenDTO> entities);
    }
}
