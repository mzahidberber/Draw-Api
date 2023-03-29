using Draw.DrawLayer.Concrete;
using Draw.Entities.Concrete;
using Draw.Core.Services.Abstract;
using Draw.Core.DependencyResolvers.Ninject;
using Draw.DrawLayer.Concrete.Model;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;

namespace Draw.DrawLayer.Abstract
{

    public abstract class BaseCommanAbstract : IBaseCommand
    {
        protected CommandData CommandMemory { get; private set; }
        protected IGeoService _geoService;
        protected IElementDal _efElementDal;
        public BaseCommanAbstract(CommandData commandMemory)
        {
            CommandMemory = commandMemory;
            _geoService=CoreInstanceFactory.GetInstance<IGeoService>();
            _efElementDal = DataInstanceFactory.GetInstance<IElementDal>();
        }

        protected async Task AddElementAsync(Element element)
        {
            await _efElementDal.AddAsync(element);
            await _efElementDal.CommitAsync();
            FinishCommand();
        }
        protected Task<ElementInformation> ReturnErrorMessageAsync(int necesaryPoint=0,string? message=null) 
        {
            var msg = "";
            if(message!=null) msg = message;
            else msg = $"Not Enough Points! Should Add Point.{necesaryPoint}/{CommandMemory.PointsList.Count}";
            return Task.FromResult(new ElementInformation { isTrue = false, message = msg });
        }

        protected abstract Task<ElementInformation> ControlCommandAsync();
        public async Task<ElementInformation> AddPointAsync(PointD point)
        {
            CommandMemory.PointsList.Add(point);
            return await ControlCommandAsync();
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
            CommandMemory.SetIsFinish(false);

        }


    }
}
