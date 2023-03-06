using Draw.Business.Abstract.BaseSevice;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IDrawBoxService:IBaseService<DrawBoxDTO>
    {
        Task<IEnumerable<LayerDTO>> GetLayersAsync(int drawId);
    }
}
