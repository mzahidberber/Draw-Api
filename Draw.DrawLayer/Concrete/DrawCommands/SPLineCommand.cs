using Draw.DrawLayer.Abstract;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class SPLineCommand:BaseCommanAbstract
    {
        public SPLineCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<ElementInformation> ControlCommand()
        {
            Console.WriteLine("SPLine Command");
            CommandMemory.SetElementTypeId(6);
            return CommandMemory.PointsList.Count <= 1 ? await AddSPLine() : await ReturnErrorMessageAsync(2);
        }

        private async Task<ElementInformation> AddSPLine()
        {
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints();
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points);
            await CommandMemory.DrawData.AddElementAsync(element);
            FinishCommand();
            return new ElementInformation { element = element, isTrue = true, message = "success" }; 
        }

        private List<Point> CreatePoints()
        {
            var list=new List<Point>();
            foreach (var point in CommandMemory.PointsList)
            {
                var p = CreatePoint(point.X, point.Y, 1);
                list.Add(p);
            }
           
            return list;
        }

        
    }
}
