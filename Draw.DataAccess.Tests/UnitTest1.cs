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
            EfElementsDal elementDal=new EfElementsDal();
            elementDal.Deneme();
            Assert.Pass();
        }
        
    }
}