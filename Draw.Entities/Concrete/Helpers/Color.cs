using Draw.Entities.Abstract;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Helpers
{
    public class Color:IEntity
    {
        public Color()
        {
            this.Pens= new List<Pen>(); 
        }
        public int ColorId { get; set; }
        public string ColorName { get; set; }   
        public int ColorRed { get; set; }
        public int ColorBlue { get; set; }
        public int ColorGreen { get; set; }

        public List<Pen> Pens { get; set; }
    }
}
