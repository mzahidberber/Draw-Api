using Draw.Core.DTOs.Concrete;
using Draw.Entities.Concrete.Helpers;

namespace Draw.Api.Models.Layer
{
    public class LayerRequest
    {
        public List<LayerDTO> layers { get; set; }
    }
}
