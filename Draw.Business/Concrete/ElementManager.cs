using Draw.Business.Mapper;
using Draw.Core.Business.Abstract;
using Draw.Core.DataAccess.Abstract;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete.Draw;
using Microsoft.EntityFrameworkCore;

namespace Draw.Business.Concrete
{
    public class ElementManager : AbstractManager, IElementService
    {
        private IElementDal _elementDal;
        public ElementManager()
        {
            _elementDal = DataInstanceFactory.GetInstance<IElementDal>();
        }

        public async Task<Response<IEnumerable<ElementDTO>>> AddAllAsync(List<ElementDTO> entities)
        {
            await base.BaseAddAllAsync<ElementDTO, Element>(entities, _elementDal);
            _elementDal = DataInstanceFactory.GetInstance<IElementDal>();
            var newList = await _elementDal.GetAllAsync().OrderByDescending(x => x.Id).Take(entities.Count()).ToListAsync();
            await _elementDal.CommitAsync();
            return Response<IEnumerable<ElementDTO>>.Success(newList.Select(d => ObjectMapper.Mapper.Map<ElementDTO>(d)), 200);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> AddAllAsync(int drawBoxId,List<ElementDTO> entities)
        {
            await base.BaseAddAllAsync<ElementDTO, Element>(entities, _elementDal);
            _elementDal = DataInstanceFactory.GetInstance<IElementDal>();
            var newList = await _elementDal.GetElementsWithDrawAsync(drawBoxId).OrderByDescending(x => x.Id).Take(entities.Count()).ToListAsync();
            await _elementDal.CommitAsync();
            return Response<IEnumerable<ElementDTO>>.Success(newList.Select(d => ObjectMapper.Mapper.Map<ElementDTO>(d)), 200);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Element>(_elementDal,x=>entities.Contains(x.Id) && x.Layer.DrawBox.UserId==userId);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<ElementDTO, Element>(_elementDal, e => e.Layer.DrawBox.UserId == userId);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetAllWithAttAsync(string userId)
        {
            var elemnts = await _elementDal.GetAllWithAttAsync(userId);
            await _elementDal.CommitAsync();
            return Response<IEnumerable<ElementDTO>>.Success(ObjectMapper.Mapper.Map<IEnumerable<ElementDTO>>(elemnts), 200);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            return await base.BaseGetAllAsync<ElementDTO, Element>(_elementDal, e => e.Layer.DrawBox.UserId == userId && e.Layer.DrawBoxId == drawId);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetAllByDrawWithAttAsync(string userId, int drawId)
        {
            var elemnts = await _elementDal.GetAllByDrawWithAttAsync(userId,drawId);
            await _elementDal.CommitAsync();
            return Response<IEnumerable<ElementDTO>>.Success(ObjectMapper.Mapper.Map<IEnumerable<ElementDTO>>(elemnts), 200);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetAllByLayerAsync(string userId, int layerId)
        {
            return await base.BaseGetAllAsync<ElementDTO, Element>(_elementDal, e => e.Layer.DrawBox.UserId == userId && e.Layer.Id == layerId);
        }

        public async Task<Response<IEnumerable<ElementDTO>>> GetAllByLayerWithAttAsync(string userId, int layerId)
        {
            var elemnts = await _elementDal.GetAllByLayerWithAttAsync(userId, layerId);
            await _elementDal.CommitAsync();
            return Response<IEnumerable<ElementDTO>>.Success(ObjectMapper.Mapper.Map<IEnumerable<ElementDTO>>(elemnts), 200);
        }

        public async Task<Response<ElementDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetWhereAsync<ElementDTO,Element>(_elementDal,x=>x.Id==entityId && x.Layer.DrawBox.UserId==userId);
        }

        public async Task<Response<ElementTypeDTO>> GetElementTypeAsync(string userId, int entityId)
        {
            var elemnt=await _elementDal.GetElementWithElementTypeAsync(userId,entityId);
            await _elementDal.CommitAsync();
            return Response<ElementTypeDTO>.Success(ObjectMapper.Mapper.Map<ElementTypeDTO>(elemnt.Type), 200);
        }

        public async Task<Response<LayerDTO>> GetLayerAsync(string userId, int entityId)
        {
            var elemnt = await _elementDal.GetElementWithLayerAsync(userId, entityId);
            await _elementDal.CommitAsync();
            return Response<LayerDTO>.Success(ObjectMapper.Mapper.Map<LayerDTO>(elemnt.Layer), 200);
        }

        public async Task<Response<PenDTO>> GetPenAsync(string userId, int entityId)
        {
            var elemnt = await _elementDal.GetElementWithPenAsync(userId, entityId);
            await _elementDal.CommitAsync();
            return Response<PenDTO>.Success(ObjectMapper.Mapper.Map<PenDTO>(elemnt.Pen), 200);
        }

        public async Task<Response<IEnumerable<PointDTO>>> GetPointsAsync(string userId, int entityId)
        {
            var elemnt = await _elementDal.GetElementWithPointsAsync(userId, entityId);
            var points = elemnt.Points.Select(e => ObjectMapper.Mapper.Map<PointDTO>(e));
            await _elementDal.CommitAsync();
            return Response<IEnumerable<PointDTO>>.Success(points, 200);
        }

        public async Task<Response<IEnumerable<RadiusDTO>>> GetRadiusesAsync(string userId, int entityId)
        {
            var elemnt = await _elementDal.GetElementWithRadiusAsync(userId, entityId);
            var radiuses = elemnt.Radiuses.Select(e => ObjectMapper.Mapper.Map<RadiusDTO>(e));
            await _elementDal.CommitAsync();
            return Response<IEnumerable<RadiusDTO>>.Success(radiuses, 200);
        }

        public async Task<Response<IEnumerable<SSAngleDTO>>> GetSSAnglesAsync(string userId, int entityId)
        {
            var elemnt = await _elementDal.GetElementWithSSAnglesAsync(userId, entityId);
            var ssangles = elemnt.SSAngles.Select(e => ObjectMapper.Mapper.Map<SSAngleDTO>(e));
            await _elementDal.CommitAsync();
            return Response<IEnumerable<SSAngleDTO>>.Success(ssangles, 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<ElementDTO> entities)
        {
            return await base.BaseUpdateAsync<ElementDTO, Element>(entities, _elementDal,() =>
            {
                var idList=entities.Select(x=>x.Id).ToList();
                var elementsCount = _elementDal.GetWhereAsync(x => idList.Contains(x.Id) && x.Layer.DrawBox.UserId == userId).Count();
                if (elementsCount != entities.Count) return false;
                else return true;
            });
        }

        
    }
}
