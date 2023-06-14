using Draw.Core.Services.Model;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;
using NLog;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class ArcCenterTwoPoint : BaseCommanAbstract
    {
        public ArcCenterTwoPoint(CommandData commandMemory) : base(commandMemory)
        {
        }
        public double radius { get; set; }
        public StartAndStopRequest? ss { get; set; }
        private Point _point1 { get; set; } = null!;
        private Point _point2 { get; set; } = null!;
        private Point _point3 { get; set; } = null!;

        public async override Task<ElementInformation> ControlCommandAsync()
        {
            CommandMemory.SetElementTypeId(4);
            return CommandMemory.PointsList.Count == 3 ? await AddArcAsync() : await ReturnErrorMessageAsync(3);
        }

        private async Task<ElementInformation> AddArcAsync()
        {
            this._point1 = base.CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            this._point2 = base.CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            this._point3 = base.CreatePoint(CommandMemory.PointsList[2].X, CommandMemory.PointsList[2].Y, 1);


            var element = await CreateElementAsync();
            //await base.AddElementAsync(element);
            FinishCommand();
            return new ElementInformation { element = element, isTrue = true, message = "success" };
        }

        private async Task<Element> CreateElementAsync()
        {
            radius = await GetRadiusAsync();
            var radiuses = new List<Radius> { new Radius { Value = radius } };
            var ssangles =await GetSSangles();
            var points = await CreatePointsAsync();
            return base.CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses,ssangles);
        }

        private async Task<List<SSAngle>> GetSSangles()
        {
            var startAndStopAngle = await _geoService.findStartAndStopAngleTwoPoint(_point1, _point2, _point3);
            ss = startAndStopAngle.data;
            return new List<SSAngle> {
                new SSAngle { Value = startAndStopAngle.data.startAngle, Type = "start" },
                new SSAngle { Value = startAndStopAngle.data.stopAngle, Type = "stop" }};
        }

        private async Task<double> GetRadiusAsync()
        {
            var data = await _geoService.FindTwoPointsLength(_point1, _point2);
            return data.data;
        }
        private async Task<List<Point>> CreatePointsAsync()
        {
            var angle = (-ss.stopAngle/32)+(-ss.startAngle/16);
            var p2 = _geoService.findPointOnCircle(_point1, radius, angle).Result.data;
            var p3 = _geoService.findPointOnCircle(_point1, radius, (-ss.stopAngle/16)+(-ss.startAngle / 16)).Result.data;
            return new List<Point> { _point1,_point2,CreatePoint(p2.X,p2.Y,1),CreatePoint(p3.X,p3.Y,1)};
        }
    }
}
