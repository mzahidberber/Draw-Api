using Draw.DrawManager.Concrete;
using Draw.DrawManager.Concrete.BaseCommand;
using Draw.Entities.Concrete;
using Draw.Entities.Concrete.Helpers;
using Draw.Manager.Concrete.DrawElements;

namespace Draw.DataAccess.Abstract.Commands
{

    public abstract class BaseCommanAbstract : IBaseCommand
    {
        protected CommandMemory CommandMemory { get; private set; }
        public BaseCommanAbstract(CommandMemory commandMemory)
        {
            CommandMemory = commandMemory;
        }

        public void SetCommandMemory(CommandMemory commandMemory) => this.CommandMemory = commandMemory;
        public virtual object AddPoint(MouseInformation mouseInformation)
        {
            CommandMemory.PointsList.Add(mouseInformation.Location);
            return this.ControlCommand();
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
                LayerId = this.CommandMemory.SelectedLayerId,
                PenId = this.CommandMemory.SelectedPenId,
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
