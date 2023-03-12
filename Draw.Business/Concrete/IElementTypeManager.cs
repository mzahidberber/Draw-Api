using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Concrete
{
    public class IElementTypeManager : IElementTypeService
    {
        public Task<Response<IEnumerable<ElementTypeDTO>>> AddAllAsync(List<ElementTypeDTO> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementTypeDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ElementTypeDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<ElementTypeDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
