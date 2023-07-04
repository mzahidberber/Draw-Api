using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete.Draw
{
    public class SSAngle : IEntity
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public double Value { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; } = null!;
    }
}
