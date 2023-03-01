using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenStyleRequest
{
    public class UserPenStyleRequest
    {
        public User user { get; set; }
        public List<PenStyle> penstyles { get; set; }
    }
}
