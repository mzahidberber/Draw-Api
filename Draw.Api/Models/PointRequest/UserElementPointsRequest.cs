using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PointRequest
{
    public class UserElementPointsRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
        public int elementId { get; set; }
    }
}
