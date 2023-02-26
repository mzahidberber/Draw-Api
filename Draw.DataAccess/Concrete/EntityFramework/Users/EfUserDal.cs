using Draw.DataAccess.Abstract.Users;
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.Entities.Concrete.Users;

namespace Draw.DataAccess.Concrete.EntityFramework.Users
{
    public class EfUserDal : EfEntityRepositoryBase<User, DrawContext>, IUserDal
    {
        public User? getUserAll(string userName)
        {
            using(DrawContext drawContext= new DrawContext())
            {
                if(drawContext.Layers!=null &&
                   drawContext.Draws != null &&
                   drawContext.Users != null &&
                   drawContext.Points != null &&
                   drawContext.Elements != null)
                {
                    var user = drawContext.Users.Where(u => u.UserName == userName).SingleOrDefault();
                    if (user != null)
                    {
                        user.DrawBoxs = drawContext.Draws.Where(db => db.User.UserName == userName).ToList();
                        foreach (var db in user.DrawBoxs)
                        {
                            db.Layers = drawContext.Layers.Where(l => l.DrawBoxId == db.DrawBoxId).ToList();
                            foreach (var layer in db.Layers)
                            {
                                layer.Elements = drawContext.Elements.Where(e => e.LayerId == layer.LayerId).ToList();
                                foreach (var element in layer.Elements)
                                {
                                    element.Points = drawContext.Points.Where(p => p.ElementId == element.ElementId).ToList();

                                }
                            }
                        }
                    }
                    return user;
                }else
                {
                    return null;
                }
                
            }
        }

        public User? IsUserId (User user)
        {
            using (DrawContext drawContext = new DrawContext())
            {
                return drawContext.Users != null ? drawContext.Users.Where(u=>u.UserId==user.UserId).SingleOrDefault() :null;
            }
        }

        public User? IsUserName(string userName)
        {
            using (DrawContext drawContext = new DrawContext())
            {
                return drawContext.Users!=null ? drawContext.Users.Where(u => u.UserName == userName).SingleOrDefault():null;
            }
        }
    }
}
