using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{
    public class Point : IEntity
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int ElementId { get; set; }
        public Element Element { get; set; } = null!;

        public int PointTypeId { get; set; }
        public PointType PointType { get; set; } = null!;
    }
}
