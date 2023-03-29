using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class SPLineCommand:BaseCommanAbstract
    {
        public SPLineCommand(CommandData commandMemory) : base(commandMemory)
        {
        }

        protected override async Task<ElementInformation> ControlCommandAsync()
        {
            Console.WriteLine("SPLine Command");
            CommandMemory.SetElementTypeId(6);
            return CommandMemory.PointsList.Count <= 1 && CommandMemory.IsFinish==true ? 
                await AddSPLine() : 
                await ReturnErrorMessageAsync(message:"Should Add Point Or Run SetIsFinish");
        }

        private Task<ElementInformation> AddSPLine()
        {
            var element = CreateElement();
            //await AddElementAsync(element);
            base.FinishCommand();
            return Task.FromResult(new ElementInformation { element = element, isTrue = true, message = "success" });
        }

        private Element CreateElement()
        {
            var list=new List<Point>();
            foreach (var point in CommandMemory.PointsList)
            {
                var p = CreatePoint(point.X, point.Y, 1);
                list.Add(p);
            }
            return CreateElementManyPoint(CommandMemory.SelectedElementTypeId, list); ;
        }

        
    }
}
