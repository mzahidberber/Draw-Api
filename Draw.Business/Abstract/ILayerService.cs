using Draw.Business.Abstract.BaseSevice;
using Draw.Core.DTOs;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;

namespace Draw.Business.Abstract
{
    public interface ILayerService:IBaseService<Layer>
    {
        Task<Response<IEnumerable<Element>>> GetElementsAsync(int entityId);
        Task<Response<Pen>> GetPenAsync(int entityId);
    }
}
