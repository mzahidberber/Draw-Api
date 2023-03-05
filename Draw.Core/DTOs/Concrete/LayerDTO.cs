using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Elements;

namespace Draw.Core.DTOs.Concrete
{
    public class LayerDTO
    {
        public int LayerId { get; set; }
        public string LayerName { get; set; } = null!;
        public bool LayerLock { get; set; }
        public bool LayerVisibility { get; set; }
        public float LayerThickness { get; set; }
        public int DrawBoxId { get; set; }
        public int PenId { get; set; }

    }
}
