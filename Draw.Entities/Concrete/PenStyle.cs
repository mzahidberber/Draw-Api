using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete
{
    public class PenStyle : IEntity
    {
        public PenStyle()
        {
            Pens = new List<Pen>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Pen> Pens { get; set; }

    }
}
