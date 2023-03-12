using Draw.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Draw.Entities.Concrete
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            DrawBoxs = new List<DrawBox>();
        }
        public ICollection<DrawBox> DrawBoxs { get; set; }
    }
}
