using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.CrosCuttingConcers.Handling;
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
            return await base.BaseAddAllAsync<DrawBoxDTO, DrawBox>(entities, _drawBoxDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            var deleteDraws = new List<DrawBox>();
            foreach (var id in entities)
            {
                var entity = await _drawBoxDal.GetByIdAsync(id);
                if (entity == null || entity.UserId != userId)
                {
                    return Response<NoDataDto>.Fail($"{id}'s entity not found", 404, true);
                }
                deleteDraws.Add(entity);
            }
            if (deleteDraws.Count > 0) deleteDraws.ForEach((c) => _drawBoxDal.Delete(c));
            await _drawBoxDal.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<DrawBoxDTO>>> GetAllAsync(string userId)
        {
            var draws = await _drawBoxDal
                .GetAllAsync(d=>d.UserId==userId)
                .Select(c => ObjectMapper.Mapper.Map<DrawBoxDTO>(c))
                .ToListAsync();
            if (draws == null) throw new CustomException("Draw Not Found");
            return Response<IEnumerable<DrawBoxDTO>>.Success(draws, 200);
        }

        public async Task<Response<DrawBoxDTO>> GetAsync(string userId, int entityId)
        {
            var draw = await _drawBoxDal.GetByIdAsync(entityId);
            if (draw == null || draw.UserId!=userId) throw new CustomException("Draw Not Found");
            return Response<DrawBoxDTO>.Success(ObjectMapper.Mapper.Map<DrawBoxDTO>(draw), 200);
        }

        public async Task<Response<IEnumerable<LayerDTO>>> GetLayersAsync(string userId, int drawId)
        {
            var draw = await _drawBoxDal.GetByIdWithLayersAsync(drawId);
            if (draw == null || draw.UserId != userId) throw new CustomException("Draw Not Found");
            var data = draw.Layers.Select(l => ObjectMapper.Mapper.Map<LayerDTO>(l));
            if (data == null) throw new CustomException("Draw in Layer Not Found");
            return Response<IEnumerable<LayerDTO>>.Success(data, 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<DrawBoxDTO> entities)
        {
            var draws = entities.Select(c => ObjectMapper.Mapper.Map<DrawBox>(c));
            draws.ToList().ForEach((d) => {
                if (d.UserId != userId) throw new CustomException("Draw Not Found");
                else _drawBoxDal.Update(d);
            });
            await _drawBoxDal.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }
    }
}
