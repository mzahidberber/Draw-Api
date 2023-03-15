using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{

    public class Element : IEntity
    {
        public Element()
        {
            Points = new List<Point>();
            Radiuses = new List<Radius>();
            SSAngles = new List<SSAngle>();
        }
        public int ElementId { get; set; }

        public int PenId { get; set; }
        public Pen Pen { get; set; }

        public int ElementTypeId { get; set; }
        public ElementType ElementType { get; set; } 

        public int LayerId { get; set; }
        public Layer Layer { get; set; } 

        public List<SSAngle> SSAngles { get; set; }

        public List<Radius> Radiuses { get; set; }

        public List<Point> Points { get; set; }



    }
}
