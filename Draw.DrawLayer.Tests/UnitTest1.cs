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
            var p1 = new Point { X = 10, Y = 0 };
            var p2 = new Point { X = 5, Y = 5 };
            var p3 = new Point { X = 3, Y = 10 };
            var result= DrawMath.FindCenterAndRadiusToTreePoint(p1, p2, p3);
            Console.WriteLine(result.Item1.X);
            Console.WriteLine(result.Item1.Y);
            Console.WriteLine(result.Item2);
        }
    }
}