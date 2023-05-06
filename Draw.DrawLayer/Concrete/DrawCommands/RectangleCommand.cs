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

        public override async Task<ElementInformation> ControlCommandAsync()
        {
            CommandMemory.SetElementTypeId(3);
            return CommandMemory.PointsList.Count == 2 ? await AddRect() : await ReturnErrorMessageAsync(2);
        }
        private Task<ElementInformation> AddRect()
        {
            var element = CreateElement();
            //await AddElementAsync(element);
            base.FinishCommand();
            return Task.FromResult(new ElementInformation { element = element, isTrue = true, message = "success" });
        }

        private Element CreateElement()
        {
            var p1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            var p2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            var p3 = DrawMath.AdditionPointPlusX(p1, DrawMath.DifferancePointsX(p1, p2));
            var p4 = DrawMath.AdditionPointPlusY(p1, DrawMath.DifferancePointsY(p1, p2));
            return CreateElementManyPoint(CommandMemory.SelectedElementTypeId, new List<Point> { p1, p2, p3, p4 });
        }

       
    }
}
