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
        public int PenStyleId { get; set; }
        public string PenStyleName { get; set; } = null!;

        public List<Pen> Pens { get; set; }

    }
}
