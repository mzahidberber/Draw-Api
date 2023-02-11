using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Helpers;

namespace Draw.Entities.Concrete.Elements
{
    public class Point:IEntity
    {
        public int PointId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }
        
        public int ElementId { get; set; }
        public Element Element { get; set; }

        public int PointTypeId { get; set; }
        public PointType PointType { get; set;}
    }
}
