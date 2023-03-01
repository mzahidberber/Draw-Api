using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ElementRequest
{
    public class UserDLElementRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
        public int elementId { get; set; }
    }
}
