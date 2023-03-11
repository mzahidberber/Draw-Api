using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Draw;
using Microsoft.AspNetCore.Identity;

namespace Draw.Entities.Concrete.Users
{
    public class User:IdentityUser,IEntity
    {
        public User()
        {
            this.DrawBoxs = new List<DrawBox>();
        }
        public ICollection<DrawBox> DrawBoxs { get; set; }
    }
}
