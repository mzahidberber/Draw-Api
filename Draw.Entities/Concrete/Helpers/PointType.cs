using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Elements;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Helpers
{
    public class PointType:IEntity
    {
        public PointType()
        {
            this.PointTypePoints = new List<Point>();
        }
        public int PointTypeId { get; set; }
        public string PointTypeName { get; set; }

        public List<Point> PointTypePoints { get; set; }
    }
}
