namespace Draw.Core.DTOs.Concrete
{
    public class ColorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }
    }
}
