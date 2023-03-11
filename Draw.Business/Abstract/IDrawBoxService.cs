using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IDrawBoxService:IBaseService<DrawBoxDTO>
    {
        Task<Response<IEnumerable<LayerDTO>>> GetLayersAsync(int drawId);
    }
}
