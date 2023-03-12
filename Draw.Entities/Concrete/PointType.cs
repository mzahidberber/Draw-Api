using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete
{
    public class PointType : IEntity
    {
        public PointType()
        {
            PointTypePoints = new List<Point>();
        }
        public int PointTypeId { get; set; }
        public string PointTypeName { get; set; } = null!;

        public List<Point> PointTypePoints { get; set; }
    }
}
