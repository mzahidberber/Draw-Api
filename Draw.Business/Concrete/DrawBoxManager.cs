using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

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
            await base.BaseAddAllAsync<DrawBoxDTO, DrawBox>(entities, _drawBoxDal);
            _drawBoxDal = DataInstanceFactory.GetInstance<IDrawBoxDal>();
            var newList = await _drawBoxDal.GetAllAsync().OrderByDescending(x=>x.Id).Take(entities.Count()).ToListAsync();
            await _drawBoxDal.CommitAsync();
            return Response<IEnumerable<DrawBoxDTO>>.Success(newList.Select(d => ObjectMapper.Mapper.Map<DrawBoxDTO>(d)), 200);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<DrawBox>(_drawBoxDal, x => entities.Contains(x.Id) && x.UserId == userId);
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
            await _drawBoxDal.CommitAsync();
            return Response<IEnumerable<LayerDTO>>.Success(layers, 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<DrawBoxDTO> entities)
        {
            return await base.BaseUpdateAsync<DrawBoxDTO, DrawBox>(entities, _drawBoxDal, () =>
            {
                var idList = entities.Select(x => x.Id).ToList();
                var elementsCount = _drawBoxDal.GetWhereAsync(x => idList.Contains(x.Id) && x.UserId == userId).Count();
                if (elementsCount != entities.Count) return false;
                else return true;
            });
        }
    }
}
