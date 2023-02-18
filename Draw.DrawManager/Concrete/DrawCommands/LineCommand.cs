using Draw.Core.CrosCuttingConcers.Caching.Microsoft;
using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Entities.Concrete.Elements;
using Draw.Entities.Concrete.Helpers;

namespace Draw.DrawManager.Concrete.DrawCommands
{
    public class LineCommand : BaseCommanAbstract
    {
        public LineCommand(CommandMemory commandMemory) : base(commandMemory)
        {
        }

        protected override object ControlCommand()
        {
            Console.WriteLine("Line Command");
            CommandMemory.SetElementTypeId(1);
            return CommandMemory.PointsList.Count == 2 ? AddLine() : ReturnErrorMessage(2);
        }

        
        private object AddLine()
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
            return new List<Point> { p1, p2 };
        }


    }
}
