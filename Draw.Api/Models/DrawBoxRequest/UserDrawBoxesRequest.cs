using Draw.Entities.Concrete.Draw;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.DrawBoxRequest
{
    public class UserDrawBoxesRequest
    {
        public User user { get; set; }
        public List<DrawBox> drawBoxes { get; set; }
    }
}
