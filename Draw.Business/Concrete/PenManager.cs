using Draw.Business.Abstract;
using Draw.Business.Mapper;
using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete.EntityFramework;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Draw.Business.Concrete
{
    public class PenManager : AbstractManager,IPenService
    {
        private IPenDal _penDal;
        public PenManager()
        {
            _penDal=DataInstanceFactory.GetInstance<IPenDal>();
        }
        public async Task<Response<IEnumerable<PenDTO>>> AddAllAsync(List<PenDTO> entities)
        {
           return await base.BaseAddAllAsync<PenDTO, Pen>(entities, _penDal);
        }

        public async Task<Response<IEnumerable<PenDTO>>> AddAllAttAsync(string userId, List<PenDTO> entities)
        {
            Console.WriteLine(userId);
            entities.ForEach((e) => { 
                e.UserId = userId;
                Console.WriteLine(e.UserId);
            });
            await base.BaseAddAllAsync<PenDTO, Pen>(entities, _penDal);
            _penDal = DataInstanceFactory.GetInstance<IPenDal>();
            var newList = await _penDal.GetAllWithAttAsync(userId).OrderByDescending(x => x.Id).Take(entities.Count()).ToListAsync();
            await _penDal.CommitAsync();
            return Response<IEnumerable<PenDTO>>.Success(newList.Select(d => ObjectMapper.Mapper.Map<PenDTO>(d)), 200);
        }

        public async Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities)
        {
            return await base.BaseDeleteAllAsync<Pen>(_penDal, x => entities.Contains(x.Id) && x.UserId == userId);
        }

        public async Task<Response<IEnumerable<PenDTO>>> GetAllAsync(string userId)
        {
            return await base.BaseGetAllAsync<PenDTO, Pen>(_penDal, e => e.UserId == userId);
        }

        public async Task<Response<IEnumerable<PenDTO>>> GetAllWithAttAsync(string userId)
        {
            var pens = await _penDal.GetAllWithAttAsync(userId).ToListAsync();
            await _penDal.CommitAsync();
            return Response<IEnumerable<PenDTO>>.Success(ObjectMapper.Mapper.Map<IEnumerable<PenDTO>>(pens), 200);
        }

        public async Task<Response<PenDTO>> GetAsync(string userId, int entityId)
        {
            return await base.BaseGetWhereAsync<PenDTO, Pen>(_penDal, x => x.Id == entityId && x.UserId == userId);
        }

        //public async Task<Response<ColorDTO>> GetColorAsync(string userId, int penId)
        //{
        //    var pen = await _penDal.GetPenWithColorAsync(userId, penId);
        //    return Response<ColorDTO>.Success(ObjectMapper.Mapper.Map<ColorDTO>(pen.PenColor), 200);
        //}

        public async Task<Response<PenStyleDTO>> GetPenStyleAsync(string userId, int penId)
        {
            var pen = await _penDal.GetPenWithPenStyleAsync(userId, penId);
            await _penDal.CommitAsync();
            return Response<PenStyleDTO>.Success(ObjectMapper.Mapper.Map<PenStyleDTO>(pen.PenStyle), 200);
        }

        public async Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<PenDTO> entities)
        {
            return await base.BaseUpdateAsync<PenDTO, Pen>(entities, _penDal, () =>
            {
                var idList = entities.Select(x => x.Id).ToList();
                var elementsCount = _penDal.GetWhereAsync(x => idList.Contains(x.Id) && x.UserId == userId).Count();
                if (elementsCount != entities.Count) return false;
                else return true;
            });
        }
    }
}
