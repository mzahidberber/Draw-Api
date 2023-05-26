namespace Draw.Core.DTOs.Concrete
{
    public class PointDTO
    {
        public int? Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int? ElementId { get; set; }

        public int? PointTypeId { get; set; }
    }
}
