using Draw.DataAccess.Abstract.Commands;
using Draw.DrawManager.Concrete.Helpers;
using Draw.Entities.Concrete.Elements;

namespace Draw.DrawManager.Concrete.DrawCommands
{
    public class CircleCenterPointCommand:BaseCommanAbstract
    {
        private Point _point1 { get; set; }
        private Point _point2 { get; set; }
        protected override object ControlCommand()
        {
            
            Console.WriteLine("CircleCenterPoint Command");
            CommandMemory.SetElementTypeId(2);
            return CommandMemory.PointsList.Count == 2 ? AddCircle() : ReturnErrorMessage(2);
        }

        private object AddCircle()
        {
            this._point1 = CreatePoint(CommandMemory.PointsList[0].X, CommandMemory.PointsList[0].Y, 1);
            this._point2 = CreatePoint(CommandMemory.PointsList[1].X, CommandMemory.PointsList[1].Y, 1);
            Console.WriteLine($"{CommandMemory.SelectedElementTypeId} Add Element");
            var points = CreatePoints();
            var radius = GetRadius();
            var radiuses = new List<Radius> { new Radius { RadiusValue = radius } };
            var element = CreateElementManyPoint(CommandMemory.SelectedElementTypeId, points,radiuses);
            CommandMemory.DrawMemory.AddElement(element);
            FinishCommand();
            return element;
        }

        private double GetRadius()
        {
            var radius = DrawMath.DifferanceTwoPoints(_point1, _point2);
            return radius;
        }

        private List<Point> CreatePoints()
        {
            var p1 = DrawMath.AdditionPointPlusX(this._point1, GetRadius());
            var p2 = DrawMath.AdditionPointPlusY(this._point1, GetRadius());
            var p3 = DrawMath.AdditionPointPlusX(this._point1, - GetRadius());
            var p4 = DrawMath.AdditionPointPlusY(this._point1, - GetRadius());
            return new List<Point> { this._point1, p1, p2, p3, p4 };
        }
    }
}
