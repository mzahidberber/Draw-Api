namespace Draw.Core.DTOs.Concrete
{
    public class LayerDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Lock { get; set; }
        public bool Visibility { get; set; }
        public float Thickness { get; set; }
        public int DrawBoxId { get; set; }
        public int PenId { get; set; }
        public PenDTO? Pen { get; set; }

    }
}
