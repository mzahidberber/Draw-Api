using Draw.Core.DTOs.Concrete;

namespace Draw.Api.Models
{
    public class LayerRequest
    {
        public int drawBoxId { get; set; }
        public List<LayerDTO> layers { get; set; }
    }
}
