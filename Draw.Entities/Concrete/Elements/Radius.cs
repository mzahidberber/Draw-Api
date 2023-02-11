using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete.Elements
{
    public class Radius:IEntity
    {
        public int RadiusId { get; set; }
        public double RadiusValue { get; set; }
        public int RadiusElementId { get; set; }
        public Element RadiusElement { get; set; }
    }
}
