using Draw.DrawLayer.Concrete.BaseCommand;
using Draw.DrawLayer.Concrete.DrawElements;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Abstract.Commands
{

    public abstract class BaseCommanAbstract : IBaseCommand
    {
        protected CommandMemory CommandMemory { get; private set; }
        public BaseCommanAbstract(CommandMemory commandMemory)
        {
            CommandMemory = commandMemory;
        }

        public void SetCommandMemory(CommandMemory commandMemory) => CommandMemory = commandMemory;
        public virtual object AddPoint(MouseInformation mouseInformation)
        {
            CommandMemory.PointsList.Add(mouseInformation.Location);
            return ControlCommand();
        }

        protected string ReturnErrorMessage(int necesaryPoint) { return $"Not Enough Points! Should Add Point.{necesaryPoint}/{CommandMemory.PointsList.Count}"; }

        protected abstract object ControlCommand();
        protected Element CreateElementManyPoint(
            int elementTypeId,
            List<Point> points,
            List<Radius>? radiuses = null,
            List<SSAngle>? SSAngles = null)
        {
            return new Element
            {
                ElementTypeId = elementTypeId,
                LayerId = CommandMemory.SelectedLayerId,
                PenId = CommandMemory.SelectedPenId,
                Points = points,
                Radiuses = radiuses ?? new List<Radius>(),
                SSAngles = SSAngles ?? new List<SSAngle>()

            };

        }
        protected Point CreatePoint(double pX, double pY, int pointTypeId)
        {
            return new Point { PointX = pX, PointY = pY, PointTypeId = pointTypeId };
        }



        public void FinishCommand()
        {
            CommandMemory.ClearPointList();
            CommandMemory.SetElementTypeId(0);
            CommandMemory.ClearEditList();
            CommandMemory.SetIsWorkingCommand(false);
        }


    }
}
