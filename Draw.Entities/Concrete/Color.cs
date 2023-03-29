using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete
{
    public class Color : IEntity
    {
        //public Color()
        //{
        //    Pens = new List<Pen>();
        //}
        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;
        public int ColorRed { get; set; }
        public int ColorBlue { get; set; }
        public int ColorGreen { get; set; }

        //public List<Pen> Pens { get; set; }
    }
}
