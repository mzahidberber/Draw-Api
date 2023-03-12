﻿using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete.EntityFramework;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{

    public class ElementManager :AbstractManager, IElementService
    {
        private IElementDal _elementDal;
        public ElementManager()
        {
            _elementDal = DataInstanceFactory.GetInstance<IElementDal>();
        }

        public async Task<Response<IEnumerable<ElementDTO>>> AddAllAsync1(List<ElementDTO> entities)
        {
            return await base.BaseAddAllAsync<ElementDTO, Element>(entities, _elementDal);
        }
        public async Task<Response<IEnumerable<ElementDTO>>> AddAllAsync(List<ElementDTO> entities)
        {
            var entitiesList = entities.Select(e => ObjectMapper.Mapper.Map<Element>(e));
            foreach (var element in entitiesList)
            {
                await _elementDal.AddAsync(element);
            }
             _elementDal.Commit();
            var data = entitiesList.Select(e => ObjectMapper.Mapper.Map<ElementDTO>(e));
            return Response<IEnumerable<ElementDTO>>.Success(data, 200);
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementDTO>>> GetAllByLayerAsync(string userId, int layerId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ElementDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ElementTypeDTO>> GetElementTypeAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<LayerDTO>> GetLayerAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenDTO>> GetPenAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PointDTO>>> GetPointsAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<RadiusDTO>>> GetRadiusesAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<SSAngleDTO>>> GetSSAnglesAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<ElementDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
