
using Draw.Business.Concrete;
using Draw.Core.Aspects.PostSharp.LoginAspects;
using Draw.Core.Draw.Abstract;
using Draw.Core.Services;


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
            GeoService.Deneme(new List<PointGeo> {
                new PointGeo { X=0,Y=0,Z=0},
                new PointGeo { X=0,Y=10,Z=0}});
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

        
    }
    public interface D
    {
        void Denemee1();
    }

    public class Draw : IDrawManager 
    { 
    }
    public class Deneme
    {
        public virtual void Denemee(string a, string b)
        {
            Console.WriteLine("deneme");
        }
        [LoginAspect(typeof(UserManager1))]
        public void Denemee1(string userName)
        {
            Console.WriteLine("func");
        }
    }
}