namespace Draw.Core.DTOs.Concrete
{
    public class ColorDTO
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;
        public int ColorRed { get; set; }
        public int ColorBlue { get; set; }
        public int ColorGreen { get; set; }
    }
}
