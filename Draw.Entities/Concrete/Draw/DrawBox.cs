using Draw.Entities.Abstract;
using System.Xml.Linq;

namespace Draw.Entities.Concrete.Draw
{
    public class DrawBox : IEntity
    {
        public DrawBox()
        {
            Layers = new List<Layer>();
            DrawCommands = new List<DrawCommand>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime EditTime { get; set; } = DateTime.Now;

        public ICollection<DrawCommand> DrawCommands { get; set; }

        public ICollection<Layer> Layers { get; set; }

        public int NumberOfLayerElements { get; set; }

        public void CalculateElements() => NumberOfLayerElements = Layers.Sum(x=>x.NumberOfElements);

    }
}
