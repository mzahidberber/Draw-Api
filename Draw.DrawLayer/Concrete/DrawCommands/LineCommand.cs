using Draw.DrawLayer.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class LineCommand : BaseCommanAbstract
    {
        public LineCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<Element> ControlCommand()
        {
            Console.WriteLine("Line Command");
            CommandMemory.SetElementTypeId(1);
            return CommandMemory.PointsList.Count == 2 ? await AddLineAsync() :await ReturnErrorMessageAsync(2);
        }

        
        private async Task<Element> AddLineAsync()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePointsAsync();
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points);
            await CommandMemory.DrawData.AddElementAsync(element);
            FinishCommand();
            return element;
        }


        private List<Point> CreatePointsAsync()
        {
            var p1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            var p2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            return new List<Point> { p1, p2 };
        }


    }
}
