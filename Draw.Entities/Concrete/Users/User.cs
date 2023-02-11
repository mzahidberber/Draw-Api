using Draw.Entities.Abstract;
using Draw.Entities.Concrete.Draw;
using System.Collections.Generic;

namespace Draw.Entities.Concrete.Users
{
    public class User:IEntity
    {
        public User()
        {
            this.DrawBoxs = new List<DrawBox>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public ICollection<DrawBox> DrawBoxs { get; set; }
    }
}
