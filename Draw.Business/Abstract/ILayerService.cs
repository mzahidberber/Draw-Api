using Draw.Business.Abstract.BaseSevice;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface ILayerService:IBaseService<LayerDTO>
    {
        Task<Response<IEnumerable<ElementDTO>>> GetElementsAsync(int entityId);
        Task<Response<PenDTO>> GetPenAsync(int entityId);
    }
}
