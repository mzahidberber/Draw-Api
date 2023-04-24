using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class PointTypeManager :AbstractManager, IPointTypeService
    {
        private IPointTypeDal _pointTypeDal;
        public PointTypeManager()
        {
            _pointTypeDal=DataInstanceFactory.GetInstance<IPointTypeDal>();
        }
        public async Task<Response<IEnumerable<PointTypeDTO>>> AddAllAsync(List<PointTypeDTO> entities)
        {
            return await base.BaseAddAllAsync<PointTypeDTO, PointType>(entities, _pointTypeDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            return await base.BaseDeleteAllAsync< PointType>(_pointTypeDal, x => entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<PointTypeDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<PointTypeDTO, PointType>(_pointTypeDal);
        }

        public async Task<Response<PointTypeDTO>> GetAsync(int entityId)
        {
            return await base.BaseGetAsync<PointTypeDTO, PointType>(entityId, _pointTypeDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<PointTypeDTO> entities)
        {
            return await base.BaseUpdateAsync<PointTypeDTO, PointType>(entities, _pointTypeDal);
        }
    }
}
