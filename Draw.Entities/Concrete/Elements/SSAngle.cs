using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete.Elements
{
    public class SSAngle:IEntity
    {
        public int SSAngleId { get; set; }
        public string SSAngleType { get; set; }= null!;
        public double SSAngleValue { get; set; }
        public int SSAngleElementId { get; set; }
        public Element SSAngleElement { get; set; }= null!;
    }
}
