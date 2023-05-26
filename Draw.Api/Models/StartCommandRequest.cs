using Draw.DrawLayer.Concrete.BaseCommand;
using Microsoft.AspNetCore.Mvc;

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
