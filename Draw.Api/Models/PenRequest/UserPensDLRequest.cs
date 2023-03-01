using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenRequest
{
    public class UserPensDLRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
        public List<Pen> pens { get; set; }
    }
}
