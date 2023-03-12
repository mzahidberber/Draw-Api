using Draw.DataAccess.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Concrete.EntityFramework
{
    public class EfLayerDal : EfEntityRepositoryBase<Layer>, ILayerDal
    {
        public override bool IsUserEntity(int entityId, string userId)
        {
            var layer = _dbSet.Where(c => c.LayerId == entityId).SingleOrDefault();
            var draw = _context.Draws.Where(d => d.DrawBoxId == layer.DrawBoxId).SingleOrDefault();

            if (draw.UserId == userId)
                return true;
            else
                return false;

        }
        //public void DeleteFromId(int layerId)
        //{
        //    using (DrawContext context = new DrawContext())
        //    {
        //        if(context.Layers!=null)
        //        {
        //            var layer = context.Layers.Where(l => l.LayerId == layerId).Single();
        //            context.Layers.Remove(layer);
        //            context.SaveChanges();
        //        }
        //    }
        //}
        //public List<Layer> GetLayersAndPen(int drawBoxId)
        //{
        //    using (DrawContext context = new DrawContext())
        //    {
        //        var layers = new List<Layer>();
        //        if(context.Pens!=null && context.Colors!=null && context.PenStyles!=null && context.Layers!=null)
        //        {

        //            foreach (var id in context.Layers.Where(l=>l.DrawBoxId==drawBoxId).Select(p => p.LayerId).ToList())
        //            {
        //                var layer = context.Layers.Where(p => p.LayerId == id).Single();
        //                layer.Pen = context.Pens.Where(u => u.PenId == layer.PenId).Single();
        //                layer.Pen.PenColor= context.Colors.Where(u => u.ColorId == layer.Pen.PenColorId).Single();
        //                layer.Pen.PenStyle = context.PenStyles.Where(u => u.PenStyleId == layer.Pen.PenStyleId).Single();
        //                layers.Add(layer);

        //            }
        //        return layers;
        //        }else
        //        {
        //            throw new NullReferenceException();
        //        }
        //    }
        //}
    }
}
