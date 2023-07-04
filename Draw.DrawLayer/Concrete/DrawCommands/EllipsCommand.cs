using Draw.Core.DrawLayer.Model;
using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.Entities.Concrete.Draw;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class EllipsCommand:BaseCommanAbstract
    {
        public EllipsCommand(CommandData commandMemory) : base(commandMemory)
        {
            
        }

        private Point _point1 { get; set; } = null!;
        private Point _point2 { get; set; } = null!;
        private Point _point3 { get; set; } = null!;
        public override async Task<ElementInformation> ControlCommandAsync()
        {
            CommandMemory.SetElementTypeId(5);
            return CommandMemory.PointsList.Count == 3 ? await AddEllips() : await ReturnErrorMessageAsync(3);
        }
        private Task<ElementInformation> AddEllips()
        {
            this._point1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            this._point2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            this._point3 = CreatePoint(CommandMemory.PointsList[2].X, CommandMemory.PointsList[2].Y, 1);


            var element = CreateElement();
            //await AddElementAsync(element);
            base.FinishCommand();
            return Task.FromResult(new ElementInformation { element = element, isTrue = true, message = "success" });
        }
        private Element CreateElement()
        {
            var points = CreatePoints();
            var radiuses = GetRadius();
            return base.CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses);
        }


        private List<Radius> GetRadius()
        {
            var radius = DrawMath.DifferanceTwoPoints(_point1, _point2);
            var radius2 = DrawMath.DifferancePointsY(_point1, _point3);
            var r1 = new Radius { Value=radius};
            var r2 = new Radius { Value=radius2};
            return new List<Radius> { r1,r2};
        }

        private List<Point> CreatePoints()
        {
            //var pcenter = DrawMath.FindCenterAndRadiusToTreePoint(_point1, _point2, _point3).Item1;
            //var p1 = DrawMath.AdditionPointPlusX(pcenter, GetRadius());
            //var p2 = DrawMath.AdditionPointPlusY(pcenter, GetRadius());
            //var p3 = DrawMath.AdditionPointPlusX(pcenter, -GetRadius());
            //var p4 = DrawMath.AdditionPointPlusY(pcenter, -GetRadius());
            return new List<Point> { _point1 };
        }
    }
}
