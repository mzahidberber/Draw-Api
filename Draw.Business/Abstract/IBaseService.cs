using Draw.Core.DTOs;

namespace Draw.Business.Abstract
{
    public interface IBaseService<T>
        where T : class
    {
        Task<Response<IEnumerable<T>>> GetAllAsync(string userId);
        Task<Response<T>> GetAsync(string userId, int entityId);
        Task<Response<IEnumerable<T>>> AddAllAsync(List<T> entities);
        Task<Response<NoDataDto>> UpdateAllAsync(string userId, List<T> entities);
        Task<Response<NoDataDto>> DeleteAllAsync(string userId, List<int> entities);

    }
}
