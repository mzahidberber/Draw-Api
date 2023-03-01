using Draw.Entities.Concrete.Helpers;
using Draw.Entities.Concrete.Users;

namespace Draw.Api.Models.ColorRequest
{
    public class UserColorsRequest
    {
        public User user { get; set; }
        public List<Color> colors { get; set; }
    }
}
