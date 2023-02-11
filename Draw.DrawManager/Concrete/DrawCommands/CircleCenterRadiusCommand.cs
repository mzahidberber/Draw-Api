using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.Helpers;
using Draw.Entities.Concrete.Elements;

namespace Draw.DrawManager.Concrete.DrawCommands
{
    public class CircleCenterRadiusCommand:BaseCommanAbstract
    {
        protected override object ControlCommand()
        {
            Console.WriteLine("CircleCenterRadiues Command");
            CommandMemory.SetElementTypeId(2);
            if (CommandMemory.SelectedRadius == 0) { CommandMemory.ClearPointList(); return "Last Set Radius"; }
            return CommandMemory.PointsList.Count == 1 && CommandMemory.SelectedRadius != 0 ? AddCircle() : ReturnErrorMessage(1);
        }

        private object AddCircle()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints(CommandMemory.SelectedRadius);
            var radiuses = new List<Radius> { new Radius { RadiusValue = CommandMemory.SelectedRadius } };
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses);
            CommandMemory.DrawMemory.AddElement(element);
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
