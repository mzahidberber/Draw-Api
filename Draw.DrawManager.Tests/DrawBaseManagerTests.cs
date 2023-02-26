using Draw.DrawManager.Concrete.BaseCommand;
using Draw.DrawManager.Concrete.HelperCommands;
using Draw.DrawManager.Concrete.Helpers;
using Draw.Entities.Concrete.Elements;
using Draw.Manager.Concrete.DrawElements;

namespace Draw.DrawManager.Tests
{
    public class DrawBaseManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DrawBaseManager_StartCommand_AddCoordinates_Test()
        {
            var mouse = new MouseInformation(10, 10, 1, 0);
            var mouse1 = new MouseInformation(20.5, 10, 1, 0);
            var mouse2 = new MouseInformation(15, 10, 1, 0);
            Concrete.DrawM drawBoxManager = new Concrete.DrawM("zahid");
            drawBoxManager.StartCommand(CommandEnums.circleTreePoint,1,2,1);
            var result=drawBoxManager.AddCoordinate(mouse);
            var result2=drawBoxManager.AddCoordinate(mouse1);
            var result3=drawBoxManager.AddCoordinate(mouse2);

            //drawBoxManager.AddRadius(5);
            //var result3=drawBoxManager.AddCoordinate(mouse2);
            //var result=drawBoxManager.AddCoordinates(mouse1);

            var results = new List<Element>();
            //results.Add(result.Item2);
            Console.WriteLine(result);
            Console.WriteLine(result2);
            if (result3 != null && result3.GetType() == typeof(Element))
            {
                results.Add((Element)result3);
            }
            
            //results.Add(result3.Item2);
            foreach (var item in results)
            {
                Console.WriteLine($"elementType : {item.ElementTypeId}");
                foreach (var p in item.Points)
                {
                    Console.WriteLine($"point :{p.PointX}---{p.PointY}");
                }
            }

            Assert.Pass();
        }
        [Test]
        public void linqDeneme()
        {
            var e = new List<Element>
            {
                new Element { ElementTypeId = 1 ,Points=new List<Point> { new Point { PointId=1}, new Point { PointId = 6 } } },
                new Element { ElementTypeId = 1 ,Points=new List<Point> { new Point { PointId=2}, new Point { PointId = 5 } } },
                new Element { ElementTypeId = 1 ,Points=new List<Point> { new Point { PointId=3}, new Point { PointId = 7 } } },
                new Element { ElementTypeId = 1 ,Points=new List<Point> { new Point { PointId=4} } },
            };
            var asd = e.SelectMany(u => u.Points).ToList();
            foreach (var p in asd)
            {
                Console.WriteLine(p.PointId);
            }
            Assert.Pass();
        }

       
        [Test]
        public void DrawBaseManager_MoveCommand_Test()
        {
            var mouse = new MouseInformation(0, 0, 1, 0);
            var mouse1 = new MouseInformation(10, 10, 1, 0);
            Concrete.DrawM drawBoxManager = new Concrete.DrawM("zahid");
            drawBoxManager.StartCommand(CommandEnums.move, 1, 2, 1);
            drawBoxManager.AddEditElementsId(new List<int> { 1,2,3 }) ;
            var result = drawBoxManager.AddCoordinate(mouse);
            var result2 = drawBoxManager.AddCoordinate(mouse1);

            Console.WriteLine(result);
            Console.WriteLine(result2);


            foreach (var item in (List<Element>)result2)
            {
                Console.WriteLine($"elementType : {item.ElementTypeId}");
                foreach (var p in item.Points)
                {
                    Console.WriteLine($"point :{p.PointX}---{p.PointY}");
                }
            }

            Assert.Pass();
        }
        [Test]
        public void asd()
        {
            var p1 = new Point { PointX = 0, PointY = 0 };
            var p2 = new Point { PointX = 10, PointY = 10};
            var p3 = new Point { PointX = 0, PointY = 40 };
            var my=DrawMath.FindCenterAndRadiusToTreePoint(p1, p2, p3);

            Console.WriteLine($"{my.Item1.PointX} {my.Item1.PointY} {my.Item2}");



            Assert.Pass();
        }

    }
}