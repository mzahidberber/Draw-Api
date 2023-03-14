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
        public string PenName { get; set; }
        public int PenColorId { get; set; }
        public Color PenColor { get; set; }

        public string PenUserId { get; set; }
        public User PenUser { get; set; }
        public int PenStyleId { get; set; }
        public PenStyle PenStyle { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Element> Elements { get; set; }

    }
}
