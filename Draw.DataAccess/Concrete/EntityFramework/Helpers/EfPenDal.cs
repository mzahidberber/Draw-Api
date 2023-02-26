using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Draw.DataAccess.Concrete.EntityFramework.Helpers
{
    public class EfPenDal:EfEntityRepositoryBase<Pen,DrawContext>,IPenDal
    {
        public List<Pen> GetPensColorAndPenStyle()
        {
            using (DrawContext context = new DrawContext())
            {
                var pens = new List<Pen>();
                if(context.Pens!=null && context.Colors!=null && context.PenStyles!=null)
                {
                    foreach (var id in context.Pens.Select(p=>p.PenId).ToList())
                    {
                        var pen = context.Pens.Where(p=>p.PenId==id).Single();
                        pen.PenColor = context.Colors.Where(u => u.ColorId == pen.PenColorId).Single();
                        pen.PenStyle = context.PenStyles.Where(u => u.PenStyleId == pen.PenStyleId).Single();
                        pens.Add(pen);

                    }
                    return pens;
                }
                else
                {
                    throw new NullReferenceException();
                }
                
            }
        }
    }
}
