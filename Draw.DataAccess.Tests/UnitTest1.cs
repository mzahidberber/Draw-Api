using Draw.DataAccess.Abstract;
using Draw.DataAccess.Concrete;
using Draw.DataAccess.Concrete.EntityFramework;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

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
            using (DrawContext context = new DrawContext())
            {
                var point = context.Points.Where(p => p.PointId == pointId).SingleOrDefault();
                var element = context.Elements.Where(e => e.ElementId == point.ElementId).SingleOrDefault();
                var layer = context.Layers.Where(l => l.LayerId == element.LayerId).SingleOrDefault();
                var draw = context.Draws.Where(d => d.DrawBoxId == layer.LayerId).SingleOrDefault();
                if (draw.UserId == userId)
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
            var element = new Element { PenId = 1, LayerId = 2, ElementTypeId = 1 };

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

        [Test]
        public void Test3()
        {
            using (DrawContext context = new DrawContext())
            {
                //var element = context.Elements.Where(e => e.ElementTypeId == 1).Include(l => l.Layer).ThenInclude(d => d.DrawBox).FirstOrDefault();
                var element1 = context.Elements.Where(e => e.Layer.DrawBox.UserId == "b21972e1-742f-4fa7-be46-1189d9cab7ca").ToList();
                element1.ForEach(e =>
                {
                    Console.WriteLine(e.ElementId);
                });
            }
        }

        [Test]
        public void Test4()
        {
            DrawContext context = new DrawContext();
            var efelementDal = new EfElementsDal(context);
            var elements= efelementDal.GetAllAsync(e => e.Layer.DrawBox.UserId == "b21972e1-742f-4fa7-be46-1189d9cab7cb").ToList();
            elements.ForEach(e => Console.WriteLine(e.ElementId));
        }


        [Test]
        public void Test5()
        {
            using (DrawContext context = new DrawContext())
            {
                var list= new List<int> { 1,2,3,6};
                var elements = context.Elements.Where(e => list.Contains(e.ElementId)).ToList();
                elements.ForEach((e) =>
                {
                    Console.WriteLine(e.ElementId);
                });
;            }
        }


        [Test]
        public void Test6()
        {
            DrawContext context = new DrawContext();
            var element = new Element {ElementId=4, PenId = 1, LayerId = 2, ElementTypeId = 3 };
            var element1 = new Element {ElementId=3, PenId = 1, LayerId = 2, ElementTypeId = 3 };
            var efelementDal = new EfElementsDal(context);
            try
            {
                efelementDal.Update(element1);
                efelementDal.Update(element);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            finally
            {
                efelementDal.Commit();
            }
            
            
            
            
        }


        [Test]
        public void Test7()
        {
            DrawContext context = new DrawContext();
            var element = new Element { ElementId = 4, PenId = 1, LayerId = 2, ElementTypeId = 3 };
            var element1 = new Element { ElementId = 3, PenId = 1, LayerId = 2, ElementTypeId = 3 };
            var efelementDal = new EfElementsDal(context);
            




        }
    }

}