using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Entities.Concrete;
using Draw.Entities.Concrete.Helpers;

namespace Draw.DrawManager.Concrete.DrawCommands
{
    public class SPLineCommand:BaseCommanAbstract
    {
        public SPLineCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override object ControlCommand()
        {
            Console.WriteLine("SPLine Command");
            CommandMemory.SetElementTypeId(6);
            return CommandMemory.PointsList.Count <= 1 ? AddSPLine() : ReturnErrorMessage(2);
        }

        private object AddSPLine()
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
