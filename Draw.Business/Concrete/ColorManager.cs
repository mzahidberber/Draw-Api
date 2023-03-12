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
            var entitiesList = entities.Select(e => ObjectMapper.Mapper.Map<Color>(e));
            foreach (var color in entitiesList)
            {
                await _colorDal.AddAsync(color);
            }
            await _unitOfWork.CommitAsync();
            var data = entitiesList.Select(e => ObjectMapper.Mapper.Map<ColorDTO>(e));
            return Response<IEnumerable<ColorDTO>>.Success(data, 200);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities)
        {
            var deleteColors = new List<Color>();
            foreach (var id in entities)
            {
                var entity = await _colorDal.GetByIdAsync(id);
                if (entity == null)
                {
                    return Response<NoDataDto>.Fail($"{id}'s entity not found", 404, true);
                }
                deleteColors.Add(entity);
            }
            if (deleteColors.Count > 0) deleteColors.ForEach((c) => _colorDal.Delete(c));
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<ColorDTO>>> GetAllAsync()
        {
            var colors =await _colorDal.GetAllAsync().Select(c => ObjectMapper.Mapper.Map<ColorDTO>(c)).ToListAsync();
            if (colors == null) throw new CustomException("Color Not Found");
            return Response<IEnumerable<ColorDTO>>.Success(colors, 200);
        }

        public async Task<Response<ColorDTO>> GetAsync(int entityId)
        {
            var color = await _colorDal.GetByIdAsync(entityId);
            if (color == null) throw new CustomException("Color Not Found");
            return Response<ColorDTO>.Success(ObjectMapper.Mapper.Map<ColorDTO>(color), 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(List<ColorDTO> entities)
        {
            var colors=entities.Select(c => ObjectMapper.Mapper.Map<Color>(c));
            colors.ToList().ForEach(c=>_colorDal.Update(c));
            await _unitOfWork.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }
    }
}
