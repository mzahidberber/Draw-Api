
using Draw.Business.Concrete;
using Draw.Core.Services;
using Draw.Entities.Concrete;
using Draw.Entities.Concrete.Draw;

namespace Draw.Core.Tests
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
            //var result= GeoService.FindTwoPointsLength(new List<PointGeo> {
            //    new PointGeo { X=0,Y=0,Z=0},
            //    new PointGeo { X=0,Y=10,Z=0}});
            var resut =new GeoService().FindTwoPointsLength(
                new Point { X = 12, Y = 0 },
                new Point { X = 1, Y = 0 });

            System.Console.WriteLine(resut.Result);
            //Console.WriteLine(result.Result);
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            //ProxyGenerator generator = new ProxyGenerator();
            //Deneme d = generator.CreateClassProxy<Deneme>(new LogginAspect());
            //d.Denemee("b","a");

            Deneme c = new Deneme();
            c.Denemee1("zahid");

            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            //ProxyGenerator generator = new ProxyGenerator();
            //Deneme d = generator.CreateClassProxy<Deneme>(new LogginAspect());
            //d.Denemee("b","a");

        //    public int Id { get; set; }
        //public double X { get; set; }
        //public double Y { get; set; }

        //public int ElementId { get; set; }
        //public Element Element { get; set; } = null!;

        //public int PointTypeId { get; set; }
        //public PointType PointType { get; set; } = null!;

            GeoService geoService = new GeoService();
            var result=geoService.findPointOnCircle(new Point { X = -87.5023, Y = 27.2857 }, 151.55553168924584, 139.45307062252132).Result.data;
            Console.WriteLine(result);

            Assert.Pass();
        }


    }
    public interface D
    {
        void Denemee1();
    }

    public class Draw  
    { 
    }
    public class Deneme
    {
        public virtual void Denemee(string a, string b)
        {
            Console.WriteLine("deneme");
        }
        public void Denemee1(string userName)
        {
            Console.WriteLine("func");
        }
    }
}