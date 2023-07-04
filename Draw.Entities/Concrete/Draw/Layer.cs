using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Draw
{
    public class Layer : IEntity
    {
        public Layer()
        {
            Elements = new List<Element>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Lock { get; set; }
        public bool Visibility { get; set; }
        public float Thickness { get; set; }

        public int DrawBoxId { get; set; }
        public DrawBox? DrawBox { get; set; }

        public int PenId { get; set; }
        public Pen? Pen { get; set; }

        public List<Element> Elements { get; set; }
    }
}
