using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PenStyleRequest
{
    public class UserPointTypeRequest
    {
        public User user { get; set; }
        public List<PointType> pointTypes { get; set; }
    }
}
