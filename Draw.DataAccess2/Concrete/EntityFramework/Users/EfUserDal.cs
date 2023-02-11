using Draw.DataAccess.Abstract.Users;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Users;

namespace Draw.DataAccess.Concrete.EntityFramework.Users
{
    public class EfUserDal : EfEntityRepositoryBase<User, DrawContext>, IUserDal
    {
        public User getUserAll(string userName)
        {
            using(DrawContext drawContext= new DrawContext())
            {
                var user=drawContext.Users.Where(u => u.UserName == userName).SingleOrDefault();
                user.DrawBoxs=drawContext.Draws.Where(db=>db.User.UserName == userName).ToList();
                foreach (var db in user.DrawBoxs)
                {
                    db.Layers=drawContext.Layers.Where(l=>l.DrawBoxId==db.DrawBoxId).ToList();
                    foreach (var layer in db.Layers)
                    {
                        layer.Elements=drawContext.Elements.Where(e=>e.LayerId==layer.LayerId).ToList();
                        foreach (var element in layer.Elements)
                        {
                            element.Points = drawContext.Points.Where(p => p.ElementId == element.ElementId).ToList();

                        }
                    }
                }
                return user;
            }
        }

        public User? IsUserId (User user)
        {
            using (DrawContext drawContext = new DrawContext())
            {
                return drawContext.Users.Where(u=>u.UserId==user.UserId).SingleOrDefault();
            }
        }

        public User? IsUserName(string userName)
        {
            using (DrawContext drawContext = new DrawContext())
            {
                return drawContext.Users.Where(u => u.UserName == userName).SingleOrDefault();
            }
        }
    }
}
