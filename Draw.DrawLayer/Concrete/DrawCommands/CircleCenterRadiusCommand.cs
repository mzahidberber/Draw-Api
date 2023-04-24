using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;
using System.Xml.Linq;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class CircleCenterRadiusCommand:BaseCommanAbstract
    {
        public CircleCenterRadiusCommand(CommandData commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<ElementInformation> ControlCommandAsync()
        {
            Console.WriteLine("CircleCenterRadiues Command");
            CommandMemory.SetElementTypeId(2);
            if (CommandMemory.SelectedRadius == 0) { 
                CommandMemory.ClearPointList(); 
                return new ElementInformation { isTrue = false, message = "Last Set Radius After Add Point" }; 
            }
            return CommandMemory.PointsList.Count == 1 && CommandMemory.SelectedRadius != 0 ? 
                await AddCircle() : 
                await ReturnErrorMessageAsync(1);
        }

        private Task<ElementInformation> AddCircle()
        {
            var element = CreateElement();
            //await AddElementAsync(element);
            base.FinishCommand();
            return Task.FromResult(new ElementInformation { element = element, isTrue = true, message = "success" });
        }

        private Element CreateElement()
        {
            var points = CreatePoints(CommandMemory.SelectedRadius);
            var radiuses = new List<Radius> { new Radius { Value = CommandMemory.SelectedRadius } };
            return CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses);
        }

        private List<Point> CreatePoints(double radius)
        {
            //4 noktayi sildim gerekirse ekle
            var pcenter = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            //var p1 = DrawMath.AdditionPointPlusX(pcenter, radius);
            //var p2 = DrawMath.AdditionPointPlusY(pcenter, radius);
            //var p3 = DrawMath.AdditionPointPlusX(pcenter, -radius);
            //var p4 = DrawMath.AdditionPointPlusY(pcenter, -radius);
            return new List<Point> { pcenter };
        }
    }
}
