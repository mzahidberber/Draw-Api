using Draw.Core.DrawLayer.Model;

namespace Draw.Api.Models
{
    public class StartCommandRequest
    {
        public CommandEnums command { get; set; }
        public int? DrawId { get; set; }
        public int? LayerId { get; set; }
        public int? PenId { get; set; }
    }
}
