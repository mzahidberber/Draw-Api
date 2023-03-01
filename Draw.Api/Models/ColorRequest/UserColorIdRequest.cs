using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ColorRequest
{
    public class UserColorIdRequest
    {
        public User user { get; set; }
        public int colorId { get; set; }
    }
}
