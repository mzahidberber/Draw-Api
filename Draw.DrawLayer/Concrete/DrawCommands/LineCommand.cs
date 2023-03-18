using Draw.DrawLayer.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class LineCommand : BaseCommanAbstract
    {
        public LineCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<ElementInformation> ControlCommand()
        {
            Console.WriteLine("Line Command");
            CommandMemory.SetElementTypeId(1);
            return CommandMemory.PointsList.Count == 2 ? await AddLineAsync() :await ReturnErrorMessageAsync(2);
        }

        
        private async Task<ElementInformation> AddLineAsync()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints();
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points);
            await CommandMemory.DrawData.AddElementAsync(element);
            FinishCommand();
            return new ElementInformation { element=element,isTrue=true,message="success"};
        }


        private List<Point> CreatePoints()
        {
            var p1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            var p2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            return new List<Point> { p1, p2 };
        }


    }
}
