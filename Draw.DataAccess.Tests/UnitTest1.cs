using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.DataAccess.Concrete.EntityFramework.Elements;


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
        
    }
}