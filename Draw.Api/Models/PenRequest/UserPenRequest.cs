using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenRequest
{
    public class UserPenRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
    }
}
