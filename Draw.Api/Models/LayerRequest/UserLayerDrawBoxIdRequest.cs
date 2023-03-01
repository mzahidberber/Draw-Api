using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.LayerRequest
{
    public class UserLayerDrawBoxIdRequest
    {
        public User user { get; set; }
        public int userLayerId { get; set; }
        public int userDrawBoxId { get; set; }
    }
}
