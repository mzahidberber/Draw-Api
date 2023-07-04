using Draw.Core.DrawLayer.Model;
using Draw.DrawLayer.Abstract;
using Draw.Entities.Concrete.Draw;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class LineCommand : BaseCommanAbstract
    {
        public LineCommand(CommandData commandMemory) : base(commandMemory)
        {
        }

        public override async Task<ElementInformation> ControlCommandAsync()
        {
            CommandMemory.SetElementTypeId(1);
            return CommandMemory.PointsList.Count == 2 ? await AddLineAsync() :await ReturnErrorMessageAsync(2);
        }

        private Task<ElementInformation> AddLineAsync()
        {
            var element = CreateElement();
            //await AddElementAsync(CreateElement());
            base.FinishCommand();
            return Task.FromResult(new ElementInformation { element = element, isTrue = true, message = "success" });
        }


        private Element CreateElement()
        {
            var p1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            var p2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            return CreateElementManyPoint(CommandMemory.SelectedElementTypeId, new List<Point> { p1,p2});
        }


    }
}
