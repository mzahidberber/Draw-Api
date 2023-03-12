namespace Draw.Core.DTOs.Concrete
{
    public class PointDTO
    {
        public int PointId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }

        public int ElementId { get; set; }

        public int PointTypeId { get; set; }
    }
}
