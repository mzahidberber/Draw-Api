using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenRequest
{
    public class UserPenIdRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
        public int penId { get; set; }
    }
}
