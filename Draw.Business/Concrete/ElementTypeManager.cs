using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class ElementTypeManager :AbstractManager, IElementTypeService
    {
        private readonly IElementTypeDal _elementTypeService;
        public ElementTypeManager()
        {
            _elementTypeService=DataInstanceFactory.GetInstance<IElementTypeDal>();
        }
        public async Task<Response<IEnumerable<ElementTypeDTO>>> AddAllAsync(List<ElementTypeDTO> entities)
        {
            return await base.BaseAddAllAsync<ElementTypeDTO, ElementType>(entities, _elementTypeService);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            return await base.BaseDeleteAllAsync<ElementType>(_elementTypeService,x=>entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<ElementTypeDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<ElementTypeDTO, ElementType>(_elementTypeService);
        }

        public async Task<Response<ElementTypeDTO>> GetAsync(int entityId)
        {
            return await base.BaseGetAsync<ElementTypeDTO, ElementType>(entityId,_elementTypeService);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<ElementTypeDTO> entities)
        {
            return await base.BaseUpdateAsync<ElementTypeDTO, ElementType>(entities,_elementTypeService);
        }
    }
}
