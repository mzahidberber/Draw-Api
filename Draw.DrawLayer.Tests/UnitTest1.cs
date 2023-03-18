using Draw.DrawLayer.Concrete.Helpers;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Tests
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
            var p1 = new Point { PointX = 10, PointY = 0 };
            var p2 = new Point { PointX = 5, PointY = 5 };
            var p3 = new Point { PointX = 3, PointY = 10 };
            var result= DrawMath.FindCenterAndRadiusToTreePoint(p1, p2, p3);
            Console.WriteLine(result.Item1.PointX);
            Console.WriteLine(result.Item1.PointY);
            Console.WriteLine(result.Item2);
        }
    }
}