using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{
    public class DrawCommand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int DrawBoxId { get; set; }
        public DrawBox DrawBox { get; set; } = null!;
    }
}
