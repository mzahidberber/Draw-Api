

using Draw.Core.CrosCuttingConcers.Handling;
using Draw.Core.DataAccess.Abstract;
using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete.Web;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfMainTitleDal:EfEntityRepositoryBaseAbstract<MainTitle>,IMainTitleDal
    {
        public EfMainTitleDal(DrawContext context):base(context) { }

        public async Task<List<MainTitle>> GetAllMainTitleWithBaseTitleAsync()
        {
            return await _dbSet
                .AsQueryable()
                .Include(x => x.BaseTitles)
                .ThenInclude(x=>x.SubTitles)
                .ToListAsync() ?? throw new CustomException("Entity Not Found");
        }
    }
}
