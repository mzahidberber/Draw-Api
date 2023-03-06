using Draw.Business.Abstract.BaseSevice;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Abstract
{
    public interface IPenService:IBaseService<PenDTO>
    {
        Task<ColorDTO> GetColorAsync( int penId);
        Task<PenStyleDTO> GetPenStyleAsync(int penId);
    }
}
