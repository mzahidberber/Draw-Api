

using Draw.Entities.Concrete.Web;

namespace Draw.Core.DataAccess.Abstract
{
    public interface IMainTitleDal:IEntityRepository<MainTitle>
    {
        Task<List<MainTitle>> GetAllMainTitleWithBaseTitleAsync();
    }
}
