using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete.Draw
{
    public class PointType : IEntity
    {
        public PointType()
        {
            Points = new List<Point>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Point> Points { get; set; }
    }
}
