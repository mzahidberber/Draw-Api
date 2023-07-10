using Draw.Business.Concrete;
using Draw.Core.DTOs.Concrete;

namespace Draw.Business.Test
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
            ElementManager elementMaanger= new ElementManager();
            var list = new List<ElementDTO> { new ElementDTO { PenId=1,TypeId=1,LayerId=1 } };
            //var result= elementMaanger.AddAllAsync1(list).Result;
            //result.Data.ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x.ElementId);
            //});
            //Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            ElementManager em=new ElementManager();
            var list = new List<ElementDTO> { 
                new ElementDTO { Id=1,LayerId=1,TypeId=3,PenId=1 } ,
                new ElementDTO { Id=2,LayerId=1,TypeId=1,PenId=2 } ,
                new ElementDTO { Id=29,LayerId=1,TypeId=1,PenId=1 } 
            };
            em.UpdateAllAsync("b21972e1-742f-4fa7-be46-1189d9cab7ca", list).Wait();
        }

        [Test]
        public void Test3()
        {
            var em = new ExeManager();
            em.VersionControl("1.0.0");
        }
    }
}