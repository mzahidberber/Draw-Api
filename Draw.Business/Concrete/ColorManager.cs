using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.DependencyResolvers.Ninject;

namespace Draw.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;
        private IUnitOfWork _unitOfWork;
        public ColorManager()
        {
            _colorDal = DataInstanceFactory.GetInstance<IColorDal>();
            _unitOfWork = DataInstanceFactory.GetInstance<IUnitOfWork>();
        }

        public async Task<Response<IEnumerable<ColorDTO>>> AddAllAsync(List<ColorDTO> entities)
        {
            var entitiesList = entities.Select(e => ObjectMapper.Mapper.Map<Entities.Concrete.Color>(e));
            foreach (var color in entitiesList)
            {
                await _colorDal.AddAsync(color);
            }
            await _unitOfWork.CommitAsync();
            var data = entitiesList.Select(e => ObjectMapper.Mapper.Map<ColorDTO>(e));
            return Response<IEnumerable<ColorDTO>>.Success(data, 200);
        }
        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entitiesId)
        {
            foreach (var id in entitiesId)
            {
                var entity = await _colorDal.GetByIdAsync(id);
                if (entity == null)
                {
                    return Response<NoDataDto>.Fail($"{id}'s entity not found", 404, true);
                }
            }
            foreach (var id in entitiesId)
            {
                var entity = await _colorDal.GetByIdAsync(id);
                _colorDal.Delete(entity);
            }
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<ColorDTO>>> GetAllAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ColorDTO>> GetAsync(string userId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<ColorDTO> entities)
        {
            throw new NotImplementedException();
        }
    }
}
