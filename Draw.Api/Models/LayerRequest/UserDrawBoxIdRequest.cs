using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.LayerRequest
{
    public class UserDrawBoxIdRequest
    {
        public User user { get; set; }
        public int userDrawBoxId { get; set; }
    }
}
