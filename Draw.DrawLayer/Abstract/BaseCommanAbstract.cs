using Draw.Core.Aspects.PostSharp.LoggingAspects;
using Draw.Core.DependencyResolvers.Ninject;
using Draw.Core.Services.Abstract;
using Draw.DataAccess.Abstract;
using Draw.DataAccess.DependencyResolvers.Ninject;
using Draw.DrawLayer.Concrete;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

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

        public abstract Task<ElementInformation> ControlCommandAsync();

        [LogAspect]
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
                TypeId = elementTypeId,
                LayerId = CommandMemory.SelectedLayerId ?? 0,
                PenId = CommandMemory.SelectedPenId ?? 0,
                Points = points,
                Radiuses = radiuses ?? new List<Radius>(),
                SSAngles = SSAngles ?? new List<SSAngle>()

            };

        }
        protected Point CreatePoint(double pX, double pY, int pointTypeId)
        {
           return new Point { X = pX, Y = pY, PointTypeId = pointTypeId };
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
