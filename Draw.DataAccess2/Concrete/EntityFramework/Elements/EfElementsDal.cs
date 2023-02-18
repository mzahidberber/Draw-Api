using Draw.DataAccess.Abstract.Elements;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;

namespace Draw.DataAccess.Concrete.EntityFramework.Elements
{
    
    public class EfElementsDal:EfEntityRepositoryBase<Element,DrawContext>,IElementDal
    {
        public void AddElementAll(Element element)
        {
            using (DrawContext context = new DrawContext())
            {
                var addedEntity = context.Entry(element);
                addedEntity.State = EntityState.Added;

                foreach (var item in element.Points)
                {
                    var adddPoint = context.Entry(item);
                    adddPoint.State = EntityState.Added;
                }
                if(element.Radiuses!= null)
                {
                    foreach (var item in element.Radiuses)
                    {
                        var addRadius = context.Entry(item);
                        addRadius.State = EntityState.Added;
                    }
                }
                
                if(element.SSAngles!= null)
                {
                    foreach (var item in element.SSAngles)
                    {
                        var addSSAngles = context.Entry(item);
                        addSSAngles.State = EntityState.Added;
                    }
                }
                

                context.SaveChanges();
            }
        }

        public List<Element> GetElementBesidePoints (List<int> elementsIdList)
        {
            using (DrawContext context = new DrawContext())
            {
                var elements = new List<Element>();
                foreach (var id in elementsIdList)
                {
                    if(context.Elements!=null && context.Points != null)
                    {
                        var element = context.Elements.Where(u => u.ElementId == id).Single();
                        element.Points = context.Points.Where(u => u.ElementId == id).ToList();
                        //element.Layer=context.Layers.Where(u => u.LayerId==element.LayerId).Single();
                        elements.Add(element);
                    }
                }
                return elements;
            }
        }

        public List<Element>? GetElementsInDrawBox(int drawBoxId)
        {
            using (DrawContext context = new DrawContext())
            {
                if (context.Elements != null && 
                    context.Points != null && 
                    context.Layers != null && 
                    context.Pens != null &&
                    context.Colors != null &&
                    context.PenStyles != null &&
                    context.Radiuses != null &&
                    context.SSAngles != null)
                { 
                    var elements = context.Elements.Where(e => e.Layer.DrawBoxId == drawBoxId).ToList();
                    foreach (var element in elements)
                    {
                        element.Layer = context.Layers.Where(l => l.LayerId == element.LayerId).Single();
                        element.Pen = context.Pens.Where(l => l.PenId == element.PenId).Single();
                        element.Pen.PenColor=context.Colors.Where(l => l.ColorId== element.Pen.PenColorId).Single();
                        element.Pen.PenStyle = context.PenStyles.Where(l => l.PenStyleId == element.Pen.PenStyleId).Single();
                        element.Pen.Elements = new List<Element>();
                        element.Pen.Layers = new List<Layer>();
                        element.Points = context.Points.Where(l => l.ElementId == element.ElementId).ToList();
                        element.Radiuses = context.Radiuses.Where(l => l.RadiusElementId == element.ElementId).ToList();
                        element.SSAngles = context.SSAngles.Where(l => l.SSAngleElementId == element.ElementId).ToList();
                        element.Layer.Elements = new List<Element>();
                    }
                
                    return elements;
                }
                else
                {
                    return null;
                }
            }
        }

        public Element? GetElementBesidePointsAndLayer(Element element)
        {
            using (DrawContext context = new DrawContext())
            {
                if (context.Points != null &&
                    context.Layers != null &&
                    context.Pens != null &&
                    context.Colors != null &&
                    context.PenStyles != null)
                {
                    element.Points = context.Points.Where(u => u.ElementId == element.ElementId).ToList();
                    element.Layer = context.Layers.Where(u => u.LayerId == element.LayerId).Single();
                    element.Layer.Pen = context.Pens.Where(p => p.PenId == element.Layer.PenId).Single();
                    element.Layer.Pen.PenColor = context.Colors.Where(c => c.ColorId == element.Layer.Pen.PenColorId).Single();
                    element.Layer.Pen.PenStyle = context.PenStyles.Where(c => c.PenStyleId == element.Layer.Pen.PenStyleId).Single();
                    return element;
                }else
                {
                    return null;
                }
                    
            }
        }
    }
}
