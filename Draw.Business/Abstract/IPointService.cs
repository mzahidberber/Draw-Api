using Draw.Business.Abstract.BaseSevice;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Abstract
{
    public interface IPointService:IBaseService<PointDTO>
    {
        Task<ElementDTO> GetElementAsync(int entityId);
        Task<PointTypeDTO> GetPointTypeAsync(int entityId);
    }
}
