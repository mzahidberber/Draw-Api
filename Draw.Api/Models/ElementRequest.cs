using Draw.Core.DTOs.Concrete;

namespace Draw.Api.Models
{
    public class ElementRequest
    {
        public int drawBoxId { get; set; }
        public List<ElementDTO> elements { get; set; }
    }
}
