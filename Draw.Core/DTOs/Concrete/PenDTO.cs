namespace Draw.Core.DTOs.Concrete
{
    public class PenDTO
    {
        public int PenId { get; set; }
        public string PenName { get; set; } = null!;
        public int PenColorId { get; set; }
        public int PenStyleId { get; set; }
    }
}
