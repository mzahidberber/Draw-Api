using Draw.Business.Mapper;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DTOs;
using Draw.DataAccess.Abstract;
using Draw.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Draw.Business.Concrete
{
    public class AbstractManager
    {
        protected async Task<Response<IEnumerable<TDTO>>> BaseAddAllAsync<TDTO, T>(List<TDTO> entities,IEntityRepository<T> dal)
            where T : class,IEntity,new()
            where TDTO : class,new()
        {
            var entitiesList = entities.Select(e => ObjectMapper.Mapper.Map<T>(e));
            foreach (var entity in entitiesList)
            {
                await dal.AddAsync(entity);
            }
            await dal.CommitAsync();
            var data = entitiesList.Select(e => ObjectMapper.Mapper.Map<TDTO>(e));
            return Response<IEnumerable<TDTO>>.Success(data, 200);
        }

        protected async Task<Response<NoDataDto>> BaseDeleteAllAsync<T>(List<int> entities, IEntityRepository<T> dal)
            where T : class, IEntity, new()
        {
            var deleteColors = new List<T>();
            foreach (var id in entities)
            {
                var entity = await dal.GetByIdAsync(id);
                if (entity == null)
                {
                    return Response<NoDataDto>.Fail($"{id}'s entity not found", 404, true);
                }
                deleteColors.Add(entity);
            }
            if (deleteColors.Count > 0) deleteColors.ForEach((c) => dal.Delete(c));
            await dal.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        protected async Task<Response<IEnumerable<TDTO>>> BaseGetAllAsync<TDTO, T>(IEntityRepository<T> dal)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            var entites = await dal.GetAllAsync().Select(c => ObjectMapper.Mapper.Map<TDTO>(c)).ToListAsync();
            if (entites == null) throw new CustomException("Entity Not Found");
            return Response<IEnumerable<TDTO>>.Success(entites, 200);
        }

        protected async Task<Response<TDTO>> BaseGetAsync<TDTO, T>(int entityId,IEntityRepository<T> dal)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            var entity = await dal.GetByIdAsync(entityId);
            if (entity == null) throw new CustomException("Entity Not Found");
            return Response<TDTO>.Success(ObjectMapper.Mapper.Map<TDTO>(entity), 200);
        }

        protected async Task<Response<NoDataDto>> BaseUpdateAsync<TDTO, T>(List<TDTO> entitiesDTO, IEntityRepository<T> dal)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            var entities = entitiesDTO.Select(c => ObjectMapper.Mapper.Map<T>(c));
            entities.ToList().ForEach(c => dal.Update(c));
            await dal.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

    }
}
