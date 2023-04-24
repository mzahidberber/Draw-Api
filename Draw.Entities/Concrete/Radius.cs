using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{
    public class Radius : IEntity
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; } = null!;
    }
}
