namespace Draw.Core.DTOs.Concrete
{
    public class DrawBoxDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string? UserId { get; set; }

        public List<LayerDTO>? layers { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? EditTime { get; set; }
    }
}
