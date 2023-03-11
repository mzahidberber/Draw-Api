using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Business.Concrete
{
    public class PointTypeManager : IPointTypeService
    {
        public Task<Response<IEnumerable<PointTypeDTO>>> AddAllAsync(List<PointTypeDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointTypeDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<PointTypeDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<PointTypeDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
