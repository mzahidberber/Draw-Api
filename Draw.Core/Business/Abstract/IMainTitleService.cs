using Draw.Core.DTOs;
using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Web;

namespace Draw.Core.Business.Abstract
{
    public interface IMainTitleService:IWebBaseService<MainTitleDTO>
    {
        Task<Response<IEnumerable<MainTitleDTO>>> GetAllWithBaseTitleAsync();
    }
}
