namespace Draw.Core.DTOs.Concrete
{
    public class PenDTO
    {
        public int PenId { get; set; }
        public string PenName { get; set; } = null!;
        //public int PenColorId { get; set; }
        public int PenStyleId { get; set; }
        public int PenRed { get; set; }
        public int PenBlue { get; set; }
        public int PenGreen { get; set; }
        //public ColorDTO PenColor { get; set; }
        public PenStyleDTO PenStyle { get; set; }
    }
}
