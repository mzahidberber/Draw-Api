using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Core.Business.Abstract
{
    public interface IDrawBoxService:IBaseService<DrawBoxDTO>
    {
        Task<Response<IEnumerable<LayerDTO>>> GetLayersAsync(string userId,int drawId);
    }
}
