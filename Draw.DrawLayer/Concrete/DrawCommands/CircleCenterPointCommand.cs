using Draw.DrawLayer.Abstract;
using Draw.DrawLayer.Concrete.Helpers;
using Draw.DrawLayer.Concrete.Model;
using Draw.Entities.Concrete;

namespace Draw.DrawLayer.Concrete.DrawCommands
{
    public class CircleCenterPointCommand:BaseCommanAbstract
    {
        private Point _point1 { get; set; } = null!;
        private Point _point2 { get; set; } = null!;
        public CircleCenterPointCommand(CommandData commandMemory) : base(commandMemory)
        {
            
        }
        protected override async Task<ElementInformation> ControlCommandAsync()
        {
            Console.WriteLine("CircleCenterPoint Command");
            CommandMemory.SetElementTypeId(2);
            return CommandMemory.PointsList.Count == 2 ? 
                await AddCircle() : 
                await ReturnErrorMessageAsync(2);
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
            var radiuses = new List<Radius> { new Radius { RadiusValue = GetRadius() } };
            return CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points, radiuses);
        }

        private double GetRadius() => DrawMath.DifferanceTwoPoints(_point1, _point2);

        private List<Point> CreatePoints()
        {
            // 4 noktayi sildim gerekirse ekle
            //var p1 = DrawMath.AdditionPointPlusX(this._point1, GetRadius());
            //var p2 = DrawMath.AdditionPointPlusY(this._point1, GetRadius());
            //var p3 = DrawMath.AdditionPointPlusX(this._point1, - GetRadius());
            //var p4 = DrawMath.AdditionPointPlusY(this._point1, - GetRadius());
            return new List<Point> { this._point1 };
        }
    }
}
