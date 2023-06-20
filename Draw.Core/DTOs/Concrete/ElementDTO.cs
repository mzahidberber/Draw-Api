namespace Draw.Core.DTOs.Concrete
{
    public class ElementDTO
    {
        public int Id { get; set; }

        public int PenId { get; set; }

        public int TypeId { get; set; }

        public int LayerId { get; set; }

        public List<PointDTO>? points { get; set; }
        public List<RadiusDTO>? radiuses { get; set; }
        public List<SSAngleDTO>? ssangles { get; set; }
    }
}
