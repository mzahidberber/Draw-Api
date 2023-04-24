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
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }

        //public List<Pen> Pens { get; set; }
    }
}
