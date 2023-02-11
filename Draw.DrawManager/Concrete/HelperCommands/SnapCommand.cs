using Draw.DrawManager.Concrete.BaseCommand;
using Draw.DrawManager.Concrete.Helpers;
using Draw.Entities.Concrete.Elements;
using Draw.Manager.Concrete.DrawElements;

namespace Draw.DrawManager.Concrete.HelperCommands
{
    public class SnapCommand
    {
        private CommandMemory _commandMemory { get; set; }
        internal void SetCommandMemory(CommandMemory commandMemory) => this._commandMemory = commandMemory;

        private List<Point> _points = new List<Point>();


        public Point GetSnapPointCoordinate(MouseInformation mouseInformation)
        {
            var elements = _commandMemory.DrawMemory.GetElementsId(_commandMemory.SnapElementsId);


            foreach (var helperEnum in _commandMemory.SnapPoints.Where(snp => snp.Value == true).ToList())
            {
                _points.AddRange(
                    elements.SelectMany(e => e.Points)
                    .ToList()
                    .Where(p => p.PointTypeId == (Int16)helperEnum.Key + 1)
                    .ToList());
            }

            var mouseposition = new Point { PointX = mouseInformation.X, PointY = mouseInformation.Y };
            List<double> mesafe = new List<double>();
            foreach (var point in _points)
            {
                mesafe.Add(DrawMath.DifferanceTwoPoints(point, mouseposition));
            }
            var enkucukindex = mesafe.IndexOf(mesafe.Min());
            var a = _points[enkucukindex];
            return a;
        }
    }
}
