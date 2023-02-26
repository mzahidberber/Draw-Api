using Draw.DataAccess.Abstract.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Helpers;

namespace Draw.DataAccess.Concrete.EntityFramework.Helpers
{
    public class EfLayerDal:EfEntityRepositoryBase<Layer,DrawContext>,ILayerDal
    {
        public List<Layer> GetLayersAndPen(int drawBoxId)
        {
            using (DrawContext context = new DrawContext())
            {
                var layers = new List<Layer>();
                if(context.Pens!=null && context.Colors!=null && context.PenStyles!=null && context.Layers!=null)
                {

                    foreach (var id in context.Layers.Where(l=>l.DrawBoxId==drawBoxId).Select(p => p.LayerId).ToList())
                    {
                        var layer = context.Layers.Where(p => p.LayerId == id).Single();
                        layer.Pen = context.Pens.Where(u => u.PenId == layer.PenId).Single();
                        layer.Pen.PenColor= context.Colors.Where(u => u.ColorId == layer.Pen.PenColorId).Single();
                        layer.Pen.PenStyle = context.PenStyles.Where(u => u.PenStyleId == layer.Pen.PenStyleId).Single();
                        layers.Add(layer);

                    }
                return layers;
                }else
                {
                    throw new NullReferenceException();
                }
            }
        }
    }
}
