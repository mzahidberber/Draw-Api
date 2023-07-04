using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Draw
{
    public class Pen : IEntity
    {
        public Pen()
        {
            Layers = new List<Layer>();
            Elements = new List<Element>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        //public int PenColorId { get; set; }
        //public Color PenColor { get; set; }

        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public int PenStyleId { get; set; }
        public PenStyle PenStyle { get; set; }
        public List<Layer> Layers { get; set; }
        public List<Element> Elements { get; set; }

    }
}
