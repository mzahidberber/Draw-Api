using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class DrawBoxManager :AbstractManager, IDrawBoxService
    {
        private IDrawBoxDal _drawBoxDal;
        public DrawBoxManager()
        {
            _drawBoxDal = DataInstanceFactory.GetInstance<IDrawBoxDal>();
        }
        public async Task<Response<IEnumerable<DrawBoxDTO>>> AddAllAsync(List<DrawBoxDTO> entities)
        {
            return await base.BaseAddAllAsync<DrawBoxDTO, DrawBox>(entities, _drawBoxDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<DrawBox>(_drawBoxDal, x => entities.Contains(x.DrawBoxId) && x.UserId == userId);
        }

        public async Task<Response<IEnumerable<DrawBoxDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<DrawBoxDTO, DrawBox>(_drawBoxDal, e => e.UserId == userId);
        }

        public async Task<Response<DrawBoxDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetAsync<DrawBoxDTO, DrawBox>(entityId,_drawBoxDal, e => e.UserId == userId);
        }

        public async Task<Response<IEnumerable<LayerDTO>>> GetLayersAsync(string userId, int drawId)
        {
            var draw = await _drawBoxDal.GetDrawWithLayersAsync(userId, drawId);
            var layers = draw.Layers.Select(e => ObjectMapper.Mapper.Map<LayerDTO>(e));
            return Response<IEnumerable<LayerDTO>>.Success(layers, 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<DrawBoxDTO> entities)
        {
            return await base.BaseUpdateAsync<DrawBoxDTO, DrawBox>(entities, _drawBoxDal, () =>
            {
                var idList = entities.Select(x => x.DrawBoxId).ToList();
                var elementsCount = _drawBoxDal.GetWhereAsync(x => idList.Contains(x.DrawBoxId) && x.UserId == userId).Count();
                if (elementsCount != entities.Count) throw new CustomException("Entity Not Found");
            });
        }
    }
}
