using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class RectangleCommand:BaseCommanAbstract
    {
        public RectangleCommand(CommandData commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<ElementInformation> ControlCommand()
        {
            Console.WriteLine("Rectangle Command");
            CommandMemory.SetElementTypeId(3);
            return CommandMemory.PointsList.Count == 2 ? await AddRect() : await ReturnErrorMessageAsync(2);
        }

        private async Task<ElementInformation> AddRect()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints();
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points);
            await AddElementAsync(element);
            FinishCommand();
            return new ElementInformation { element = element, isTrue = true, message = "success" };
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
