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

        public Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementTypeDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<ElementTypeDTO>> GetAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(List<ElementTypeDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
