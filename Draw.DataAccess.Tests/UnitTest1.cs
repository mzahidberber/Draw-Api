using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.DataAccess.Concrete.EntityFramework.Helpers;
using Draw.DataAccess.Concrete.EntityFramework.Users;

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
            Assert.Pass();
        }
        [Test]
        public void data_test()
        {
            using(DrawContext context=new DrawContext())
            {
                var a = context.Colors.Where(u => u.ColorId == 1).Single();
                Console.WriteLine(a);
            }
            //var efuserdal=new EfColorDal();
            //var users=efuserdal.GetAll();
            //Console.WriteLine(users);
        }
    }
}