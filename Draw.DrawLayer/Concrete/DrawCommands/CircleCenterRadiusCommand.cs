using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class CircleCenterRadiusCommand:BaseCommanAbstract
    {
        public CircleCenterRadiusCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<Element> ControlCommand()
        {
            Console.WriteLine("CircleCenterRadiues Command");
            CommandMemory.SetElementTypeId(2);
            if (CommandMemory.SelectedRadius == 0) { CommandMemory.ClearPointList(); throw new CustomException("Last Set Radius"); }
            return CommandMemory.PointsList.Count == 1 && CommandMemory.SelectedRadius != 0 ? await AddCircle() : await ReturnErrorMessageAsync(1);
        }

        private async Task<Element> AddCircle()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints(CommandMemory.SelectedRadius);
            var radiuses = new List<Radius> { new Radius { RadiusValue = CommandMemory.SelectedRadius } };
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses);
            await CommandMemory.DrawData.AddElementAsync(element);
            FinishCommand();
            return element;
        }

        private List<Point> CreatePoints(double radius)
        {
            var pcenter = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            var p1 = DrawMath.AdditionPointPlusX(pcenter, radius);
            var p2 = DrawMath.AdditionPointPlusY(pcenter, radius);
            var p3 = DrawMath.AdditionPointPlusX(pcenter, -radius);
            var p4 = DrawMath.AdditionPointPlusY(pcenter, -radius);
            return new List<Point> { pcenter, p1, p2, p3, p4 };
        }
    }
}
