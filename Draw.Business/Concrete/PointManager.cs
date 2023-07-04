using Draw.Business.Mapper;
using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Draw;

namespace Draw.Business.Concrete
{
    public class PointManager :AbstractManager, IPointService
    {
        private readonly IPointDal _pointDal;
        public PointManager()
        {
            _pointDal=DataInstanceFactory.GetInstance<IPointDal>();
        }
        public async Task<Response<IEnumerable<PointDTO>>> AddAllAsync(List<PointDTO> entities)
        {
            return await base.BaseAddAllAsync<PointDTO, Point>(entities, _pointDal);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Point>(_pointDal, x => entities.Contains(x.Id) && x.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<PointDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<PointDTO, Point>(_pointDal, e => e.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<PointDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            return await base.BaseGetAllAsync<PointDTO, Point>(_pointDal, e => e.Element.Layer.DrawBox.UserId == userId && e.Element.Layer.DrawBoxId == drawId);
        }

        public async Task<Response<IEnumerable<PointDTO>>> GetAllByElementAsync(string userId, int elementId)
        {
            return await base.BaseGetAllAsync<PointDTO, Point>(_pointDal, e => e.Element.Layer.DrawBox.UserId == userId && e.ElementId == elementId);
        }

        public async Task<Response<IEnumerable<PointDTO>>> GetAllByLayerAsync(string userId, int layerId)
        {
            return await base.BaseGetAllAsync<PointDTO, Point>(_pointDal, e => e.Element.Layer.DrawBox.UserId == userId && e.Element.LayerId == layerId);
        }

        public async Task<Response<PointDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetWhereAsync<PointDTO, Point>(_pointDal, x => x.Id == entityId && x.Element.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<ElementDTO>> GetElementAsync(string userId, int entityId)
        {
            var point = await _pointDal.GetPointWithElementAsync(userId, entityId);
            await _pointDal.CommitAsync();
            return Response<ElementDTO>.Success(ObjectMapper.Mapper.Map<ElementDTO>(point.Element), 200);
        }

        public async Task<Response<PointTypeDTO>> GetPointTypeAsync(string userId, int entityId)
        {
            var point = await _pointDal.GetPointWithElementAsync(userId, entityId);
            await _pointDal.CommitAsync();
            return Response<PointTypeDTO>.Success(ObjectMapper.Mapper.Map<PointTypeDTO>(point.PointType), 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<PointDTO> entities)
        {
            return await base.BaseUpdateAsync<PointDTO, Point>(entities, _pointDal, () =>
            {
                var idList = entities.Select(x => x.Id).ToList();
                var elementsCount = _pointDal.GetWhereAsync(x => idList.Contains(x.Id) && x.Element.Layer.DrawBox.UserId == userId).Count();
                if (elementsCount != entities.Count) return false;
                else return true;
            });
        }
    }
}
