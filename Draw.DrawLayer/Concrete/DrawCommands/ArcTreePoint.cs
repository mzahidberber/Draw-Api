using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    internal class ArcTreePoint: BaseCommanAbstract
    {
        public ArcTreePoint(CommandData commandMemory) : base(commandMemory)
        {
        }

        private Point _point1 { get; set; } = null!;
        private Point _point2 { get; set; } = null!;
        private Point _point3 { get; set; } = null!;

        protected async override Task<ElementInformation> ControlCommandAsync()
        {
            ///////Düzenle
            CommandMemory.SetElementTypeId(4);
            Console.WriteLine("arcCenterTwoPoint Command");
            return CommandMemory.PointsList.Count == 3 ? await AddArcAsync() : await ReturnErrorMessageAsync(3);
        }

        private async Task<ElementInformation> AddArcAsync()
        {
            this._point1 = base.CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            this._point2 = base.CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            this._point3 = base.CreatePoint(CommandMemory.PointsList[2].X, CommandMemory.PointsList[2].Y, 1);


            var element = await CreateElementAsync();
            //await base.AddElementAsync(element);
            base.FinishCommand();
            return new ElementInformation { element = element, isTrue = true, message = "success" };
        }

        private async Task<Element> CreateElementAsync()
        {
            var points = await CreatePointsAsync();
            var radiuses = new List<Radius> { new Radius { RadiusValue = await GetRadiusAsync() } };
            var ssangles = await GetSSangles();
            return base.CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses, ssangles);
        }

        private async Task<List<SSAngle>> GetSSangles()
        {
            //var data = await _geoService.FindSSAngles();
            return new List<SSAngle> {
                new SSAngle { SSAngleValue = 10, SSAngleType = "start" },
                new SSAngle { SSAngleValue = 10, SSAngleType = "stop" } };
        }

        private async Task<double> GetRadiusAsync()
        {
            var data = await _geoService.FindCenterAndRadius(_point1, _point2, _point3);
            return data.radius;
        }

        private async Task<List<Point>> CreatePointsAsync()
        {
            //var pcenter = _geoService.FindCenterAndRadius(_point1, _point2, _point3).Result.data.centerPoint;
            var data = await _geoService.FindCenterAndRadius(_point1, _point2, _point3);
            var pcenter = data.centerPoint;
            //var p1 = DrawMath.AdditionPointPlusX(pcenter, GetRadiusAsync());
            //var p2 = DrawMath.AdditionPointPlusY(pcenter, GetRadiusAsync());
            //var p3 = DrawMath.AdditionPointPlusX(pcenter, -GetRadiusAsync());
            //var p4 = DrawMath.AdditionPointPlusY(pcenter, -GetRadiusAsync());
            return new List<Point> { pcenter };
        }
    }
}
