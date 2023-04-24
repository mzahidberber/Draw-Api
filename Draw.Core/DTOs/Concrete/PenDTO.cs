namespace Draw.Core.DTOs.Concrete
{
    public class PenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public int PenColorId { get; set; }
        public int PenStyleId { get; set; }
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }
        //public ColorDTO PenColor { get; set; }
        public PenStyleDTO PenStyle { get; set; }
    }
}
