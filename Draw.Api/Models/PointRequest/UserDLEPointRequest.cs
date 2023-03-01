using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.PointRequest
{
    public class UserDLEPointRequest
    {
        public User user { get; set; }
        public int drawId { get; set; }
        public int layerId { get; set; }
        public int elementId { get; set; }
        public int pointId { get; set; }
    }
}
