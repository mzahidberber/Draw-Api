using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.LayerRequest
{
    public class UserLayersDrawBoxIdRequest
    {
        public User user { get; set; }
        public List<Layer> layers { get; set; }
        public int userDrawBoxId { get; set; }
    }
}
