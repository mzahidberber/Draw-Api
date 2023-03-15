using Draw.DrawLayer.Abstract.Commands;
using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class RectangleCommand:BaseCommanAbstract
    {
        public RectangleCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override object ControlCommand()
        {
            Console.WriteLine("Rectangle Command");
            CommandMemory.SetElementTypeId(3);
            return CommandMemory.PointsList.Count == 2 ? AddRect() : ReturnErrorMessage(2);
        }

        private object AddRect()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints();
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points);
            CommandMemory.DrawMemory.AddElement(element);
            FinishCommand();
            return element;
        }

        private List<Point> CreatePoints()
        {
            var p1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            var p2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            var p3 = DrawMath.AdditionPointPlusX(p1, DrawMath.DifferancePointsX(p1, p2));
            var p4 = DrawMath.AdditionPointPlusY(p1, DrawMath.DifferancePointsY(p1, p2));
            return new List<Point> { p1, p2 , p3 , p4 };
        }

       
    }
}
