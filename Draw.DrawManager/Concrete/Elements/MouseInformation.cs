using Draw.DataAccess.Concrete.Elements;

namespace Draw.Manager.Concrete.DrawElements
{
    public class MouseInformation
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Button { get; set; }
        public int Delta { get; set; }
        public PointD Location { get; set; }

        public MouseInformation(double x, double y, int button, int delta)
        {
            this.X = x;
            this.Y = y;
            this.Button = button;
            this.Delta = delta;
            this.Location = new PointD(x, y);
        }

    }
}
