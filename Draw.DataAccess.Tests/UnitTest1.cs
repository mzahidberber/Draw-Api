
using Draw.DataAccess.Concrete.EntityFramework.Context;
using Draw.DataAccess.Concrete.EntityFramework.Elements;
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
            EfElementsDal elementDal=new EfElementsDal();
            elementDal.Deneme();
            Assert.Pass();
        }
        
    }
}