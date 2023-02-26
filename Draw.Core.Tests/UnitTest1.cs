using Draw.Core.Services;
using Newtonsoft.Json;

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
    }
}