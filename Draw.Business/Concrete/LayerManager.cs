using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.Business.Concrete
{
    public class LayerManager : ILayerService
    {
        private readonly ILayerDal _layerDal;
        private readonly IUnitOfWork _unitOfWork;
        public LayerManager()
        {
            _unitOfWork = DataInstanceFactory.GetInstance<IUnitOfWork>();
            _layerDal=DataInstanceFactory.GetInstance<ILayerDal>(); 
        }
        
        public async Task<Response<IEnumerable<LayerDTO>>> AddAllAsync(List<LayerDTO> entities)
        {
            var layerList=new List<LayerDTO>();
            foreach (var entity in entities)
            {
                await _layerDal.AddAsync(ObjectMapper.Mapper.Map<Layer>(entity));
                await _unitOfWork.CommitAsync();
                layerList.Add(ObjectMapper.Mapper.Map<LayerDTO>(entity));
            }
            return Response<IEnumerable<LayerDTO>>.Success(layerList,200);
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LayerDTO>>> GetAllByDrawAsync(string userId, int drawId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<LayerDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ElementDTO>>> GetElementsAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PenDTO>> GetPenAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<LayerDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
