using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenStyleRequest
{
    public class UserPenStyleIdRequest
    {
        public User user { get; set; }
        public int penstyleId { get; set; }
    }
}
