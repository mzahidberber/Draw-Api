using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete
{
    public class Pen : IEntity
    {
        public Pen()
        {
            Layers = new List<Layer>();
            Elements = new List<Element>();
        }
        public int PenId { get; set; }
        public string PenName { get; set; } = null!;
        public int PenColorId { get; set; }
        public Color PenColor { get; set; } = null!;
        public int PenStyleId { get; set; }
        public PenStyle PenStyle { get; set; } = null!;
        public List<Layer> Layers { get; set; }
        public List<Element> Elements { get; set; }

    }
}
