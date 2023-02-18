using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Helpers
{
    public class PenStyle:IEntity
    {
        public PenStyle()
        {
            this.Pens = new List<Pen>();
        }
        public int PenStyleId { get; set; }
        public string PenStyleName { get; set; }= null!;

        public List<Pen> Pens { get; set; }

    }
}
