using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class CircleTwoPointsCommand : BaseCommanAbstract
    {
        public CircleTwoPointsCommand(CommandData commandMemory) : base(commandMemory)
        {
            
        }

        private Point _point1 { get; set; } = null!;
        private Point _point2 { get; set; } = null!;
        public override async Task<ElementInformation> ControlCommandAsync()
        {
            CommandMemory.SetElementTypeId(2);
            return CommandMemory.PointsList.Count == 2 ?await  AddCircle() : await ReturnErrorMessageAsync(2);
        }
        private Task<ElementInformation> AddCircle()
        {
            this._point1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            this._point2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);

            var element = CreateElement();
            //await AddElementAsync(element);
            base.FinishCommand();
            return Task.FromResult(new ElementInformation { element = element, isTrue = true, message = "success" });
        }
        private Element CreateElement()
        {
            var points = CreatePoints();
            var radiuses = new List<Radius> { new Radius { Value = GetRadius() } };
            return base.CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses);
        }
        private double GetRadius() => DrawMath.DifferanceTwoPoints(_point1, _point2) / 2;

        private List<Point> CreatePoints()
        {
            var pcenter = DrawMath.FindBetweenPointToTwoPoint(_point1, _point2, 1);
            //var p1 = DrawMath.AdditionPointPlusX(pcenter, GetRadius());
            //var p2 = DrawMath.AdditionPointPlusY(pcenter, GetRadius());
            //var p3 = DrawMath.AdditionPointPlusX(pcenter, -GetRadius());
            //var p4 = DrawMath.AdditionPointPlusY(pcenter, -GetRadius());
            return new List<Point> { pcenter };
        }
    }
}
