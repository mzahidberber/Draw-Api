using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ElementRequest
{
    public class UserElementRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
    }
}
