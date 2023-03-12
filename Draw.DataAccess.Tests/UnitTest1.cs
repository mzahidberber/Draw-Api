using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete;
using Draw.DataAccess.Concrete.EntityFramework;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;

namespace Draw.DataAccess.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            //EfElementsDal elementDal=new EfElementsDal();
            //elementDal.Deneme();
            int pointId = 7;
            string userId = "b21972e1-742f-4fa7-be46-1189d9cab7cc";
            using (DrawContext context=new DrawContext())
            {
                var point=context.Points.Where(p=>p.PointId==pointId).SingleOrDefault();
                var element=context.Elements.Where(e=>e.ElementId==point.ElementId).SingleOrDefault();
                var layer=context.Layers.Where(l=>l.LayerId==element.LayerId).SingleOrDefault();
                var draw = context.Draws.Where(d => d.DrawBoxId == layer.LayerId).SingleOrDefault();
                if(draw.UserId==userId)
                {
                    Console.WriteLine(point.PointX);
                }
                else
                {
                    Console.WriteLine("yok");
                }
            }
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var element = new Element { PenId=1,LayerId=2,ElementTypeId=1};

            var elementDAl = DataInstanceFactory.GetInstance<IElementDal>();
            //var unitwork = DataInstanceFactory.GetInstance<IUnitOfWork>();
            //var db=DataInstanceFactory.GetInstance<DrawContext>();
            //var elementDAl = new EfElementsDal(db);
            //var unitwork = new UnitOfWork(db);

            elementDAl.AddAsync(element).Wait();
            elementDAl.Commit();
            //unitwork.CommitAsync().Wait();
            //elementDAl._context.SaveChanges();
            //conte.SaveChanges();
            //var context=new DrawContext();
            //var dbset = context.Set<Element>();
            //var c=dbset.AddAsync(element).Result;
            //context.SaveChangesAsync().Wait();

            //using (DrawContext context=new DrawContext())
            //{
            //    //var a=context.Elements.AddAsync(element).Result;
            //    var dbset = context.Set<Element>();
            //    var b=dbset.AddAsync(element).Result;
            //    //context.SaveChangesAsync().Wait();
            //    context.SaveChangesAsync().Wait();
            //}
        }

    }
}