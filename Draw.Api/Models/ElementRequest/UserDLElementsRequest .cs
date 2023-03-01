using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ElementRequest
{
    public class UserDLElementsRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
        public List<Element> elements { get; set; }
    }
}
