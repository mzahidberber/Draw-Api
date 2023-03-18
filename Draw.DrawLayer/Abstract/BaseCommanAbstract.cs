﻿using Draw.DrawLayer.Concrete;
using Draw.Entities.Concrete;
using Draw.Core.Services.Abstract;
using Draw.Core.DependencyResolvers.Ninject;
using Draw.DrawLayer.Concrete.Model;

namespace Draw.DrawLayer.Abstract
{

    public abstract class BaseCommanAbstract : IBaseCommand
    {
        protected CommandMemory CommandMemory { get; private set; }
        protected IGeoService _geoService;
        public BaseCommanAbstract(CommandMemory commandMemory)
        {
            CommandMemory = commandMemory;
            _geoService=CoreInstanceFactory.GetInstance<IGeoService>();
        }
        protected Task<ElementInformation> ReturnErrorMessageAsync(int necesaryPoint) 
        {
            var msg = $"Not Enough Points! Should Add Point.{necesaryPoint}/{CommandMemory.PointsList.Count}";
            return Task.FromResult(new ElementInformation { isTrue = false, message = msg });
        }

        protected abstract Task<ElementInformation> ControlCommand();
        public async Task<ElementInformation> AddPointAsync(PointD point)
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
