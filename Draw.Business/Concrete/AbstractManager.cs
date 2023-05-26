using Draw.Business.Mapper;
using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DTOs;
using Draw.DataAccess.Abstract;
using Draw.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;

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

        protected async Task<Response<NoDataDto>> BaseDeleteAllAsync<T>(IEntityRepository<T> dal,Expression<Func<T,bool>> filter)
            where T : class, IEntity, new()
        {
            var entites = dal.GetWhereAsync(filter);
            if (entites == null) return Response<NoDataDto>.Fail($"entities not found", 404, true);
            else await entites.ForEachAsync(e => dal.Delete(e));
            await dal.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

        protected async Task<Response<IEnumerable<TDTO>>> BaseGetAllAsync<TDTO, T>(IEntityRepository<T> dal, Expression<Func<T, bool>>? filter=null)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            List<TDTO> entities;
            if(filter!=null) entities = await dal.GetWhereAsync(filter).Select(c => ObjectMapper.Mapper.Map<TDTO>(c)).ToListAsync();
            else entities = await dal.GetAllAsync().Select(c => ObjectMapper.Mapper.Map<TDTO>(c)).ToListAsync();
            await dal.CommitAsync();
            if (entities == null) throw new CustomException("Entity Not Found");
            return Response<IEnumerable<TDTO>>.Success(entities, 200);
        }


        protected async Task<Response<TDTO>> BaseGetWhereAsync<TDTO, T>(IEntityRepository<T> dal, Expression<Func<T, bool>> filter = null)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            var entity = await dal.GetWhereAsync(filter).FirstOrDefaultAsync();
            if (entity == null) throw new CustomException("Entity Not Found");
            await dal.CommitAsync();
            return Response<TDTO>.Success(ObjectMapper.Mapper.Map<TDTO>(entity), 200);
        }

        protected async Task<Response<TDTO>> BaseGetAsync<TDTO, T>(int entityId,IEntityRepository<T> dal, Expression<Func<T, bool>>? filter = null)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            var entity = await dal.GetByIdAsync(entityId);
            if (entity == null) throw new CustomException("Entity Not Found");
            await dal.CommitAsync();
            return Response<TDTO>.Success(ObjectMapper.Mapper.Map<TDTO>(entity), 200);
        }

        protected async Task<Response<NoDataDto>> BaseUpdateAsync<TDTO, T>(List<TDTO> entitiesDTO, IEntityRepository<T> dal,Func<bool>? userControl=null)
            where T : class, IEntity, new()
            where TDTO : class, new()
        {
            var entities = entitiesDTO.Select(c => ObjectMapper.Mapper.Map<T>(c));
            if (userControl != null)
            {
                var result= userControl.Invoke();
                if(result == false) return Response<NoDataDto>.Fail("Entity Not Found",404,true); 
            }
            entities.ToList().ForEach(c =>dal.Update(c));
            await dal.CommitAsync();
            return Response<NoDataDto>.Success(200);
        }

    }
}
