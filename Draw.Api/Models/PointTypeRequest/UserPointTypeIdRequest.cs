using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenStyleRequest
{
    public class UserPointTypeIdRequest
    {
        public User user { get; set; }
        public int pointTypeId { get; set; }
    }
}
