
using Draw.Business.Mapper;
using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Web;

namespace Draw.Business.Concrete
{
    public class MainTitleManager : AbstractManager, IMainTitleService
    {
        private IMainTitleDal _mainTitleDal;
        public MainTitleManager()
        {
            _mainTitleDal = DataInstanceFactory.GetInstance<IMainTitleDal>();
        }
        public async Task<Response<IEnumerable<MainTitleDTO>>> GetAllWithBaseTitleAsync()
        {
            var titles=await _mainTitleDal.GetAllMainTitleWithBaseTitleAsync();
            await _mainTitleDal.CommitAsync();
            var data = titles.Select(e => ObjectMapper.Mapper.Map<MainTitleDTO>(e));
            return Response<IEnumerable<MainTitleDTO>>.Success(data, 200);
        }
        public async Task<Response<IEnumerable<MainTitleDTO>>> AddAllAsync(List<MainTitleDTO> entities)
        {
            return await base.BaseAddAllAsync<MainTitleDTO, MainTitle>(entities, _mainTitleDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync( List<int> entities)
        {
            return await base.BaseDeleteAllAsync<MainTitle>(_mainTitleDal, x => entities.Contains(x.Id));
        }

        public async Task<Response<IEnumerable<MainTitleDTO>>> GetAllAsync()
        {
            return await base.BaseGetAllAsync<MainTitleDTO, MainTitle>(_mainTitleDal);
        }

        public async Task<Response<MainTitleDTO>> GetAsync( int entityId)
        {
            return await base.BaseGetAsync<MainTitleDTO, MainTitle>(entityId, _mainTitleDal);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync( List<MainTitleDTO> entities)
        {
            return await base.BaseUpdateAsync<MainTitleDTO, MainTitle>(entities, _mainTitleDal);
        }
    }
}
