using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{
    public class DrawBox : IEntity
    {
        public DrawBox()
        {
            Layers = new List<Layer>();
            DrawCommands = new List<DrawCommand>();
        }
        public int DrawBoxId { get; set; }
        public string DrawName { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<DrawCommand> DrawCommands { get; set; }

        public ICollection<Layer> Layers { get; set; }
    }
}
