using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Helpers;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Elements
{
    public class Element:IEntity
    {
        public Element()
        {
            this.Points = new List<Point>();
            this.Radiuses = new List<Radius>();
            this.SSAngles = new List<SSAngle>();
        }
        public int ElementId { get; set; }

        public int PenId { get; set; }
        public Pen Pen { get; set; }= null!;

        public int ElementTypeId { get; set; }
        public ElementType ElementType { get; set; }= null!;

        public int LayerId { get; set; }
        public Layer Layer { get; set; }= null!;

        public List<SSAngle> SSAngles { get; set; }

        public List<Radius> Radiuses { get; set; }

        public List<Point> Points { get; set; }


        
    }
}
