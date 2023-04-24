using Draw.Business.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class ColorManager :AbstractManager,IColorService
    {
        private IColorDal _colorDal;
        public ColorManager()
        {
            _colorDal = DataInstanceFactory.GetInstance<IColorDal>();
        }

        public async Task<Response<IEnumerable<ColorDTO>>> AddAllAsync(List<ColorDTO> entities)
        {
            return await base.BaseAddAllAsync<ColorDTO,Color>(entities, _colorDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Color>(_colorDal,x => entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<ColorDTO>>> GetAllAsync()
        {
           return await base.BaseGetAllAsync<ColorDTO,Color>(_colorDal);
        }

        public async Task<Response<ColorDTO>> GetAsync(int entityId)
        {
            return await base.BaseGetAsync<ColorDTO, Color>(entityId, _colorDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<ColorDTO> entities)
        {
            return await base.BaseUpdateAsync(entities,_colorDal);
        }
    }
}
