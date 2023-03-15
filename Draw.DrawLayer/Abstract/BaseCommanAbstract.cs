using Draw.Core.CrosCuttingConcers.Handling;
using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.Elements;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Abstract
{

    public abstract class BaseCommanAbstract : IBaseCommand
    {
        protected CommandMemory CommandMemory { get; private set; }
        public BaseCommanAbstract(CommandMemory commandMemory)
        {
            CommandMemory = commandMemory;
        }
        protected Task<Element> ReturnErrorMessageAsync(int necesaryPoint) 
        { 
            throw new CustomException($"Not Enough Points! Should Add Point.{necesaryPoint}/{CommandMemory.PointsList.Count}"); 
        }

        protected abstract Task<Element> ControlCommand();
        public async Task<Element> AddPointAsync(PointD point)
        {
            CommandMemory.PointsList.Add(point);
            return await ControlCommand();
        }
        
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
