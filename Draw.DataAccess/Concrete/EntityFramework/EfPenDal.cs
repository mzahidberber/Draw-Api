using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfPenDal : EfEntityRepositoryBase<Pen>, IPenDal
    {
        //public List<Pen> GetPensColorAndPenStyle()
        //{
        //    using (DrawContext context = new DrawContext())
        //    {
        //        var pens = new List<Pen>();
        //        if(context.Pens!=null && context.Colors!=null && context.PenStyles!=null)
        //        {
        //            foreach (var id in context.Pens.Select(p=>p.PenId).ToList())
        //            {
        //                var pen = context.Pens.Where(p=>p.PenId==id).Single();
        //                pen.PenColor = context.Colors.Where(u => u.ColorId == pen.PenColorId).Single();
        //                pen.PenStyle = context.PenStyles.Where(u => u.PenStyleId == pen.PenStyleId).Single();
        //                pens.Add(pen);

        //            }
        //            return pens;
        //        }
        //        else
        //        {
        //            throw new NullReferenceException();
        //        }

        //    }
        //}
    }
}
