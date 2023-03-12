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
            var list = new List<ElementDTO> { new ElementDTO { PenId=1,ElementTypeId=1,LayerId=1 } };
            var result= elementMaanger.AddAllAsync1(list).Result;
            //result.Data.ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x.ElementId);
            //});
            //Assert.Pass();
        }
    }
}