using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.DrawBoxRequest
{
    public class UserDrawBoxRequest
    {
        public User user { get; set; }
        public int drawBoxId { get; set; }
    }
}
