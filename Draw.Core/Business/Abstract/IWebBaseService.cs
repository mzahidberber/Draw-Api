using Draw.Core.DTOs;

namespace Draw.Core.Business.Abstract
{
    public interface IWebBaseService<T>
        where T : class
    {
        Task<Response<IEnumerable<T>>> GetAllAsync();
        Task<Response<T>> GetAsync(int entityId);
        Task<Response<IEnumerable<T>>> AddAllAsync(List<T> entities);
        Task<Response<NoDataDto>> UpdateAllAsync(List<T> entities);
        Task<Response<NoDataDto>> DeleteAllAsync(List<int> entities);
    }
}
