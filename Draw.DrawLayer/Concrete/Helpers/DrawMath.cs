using Draw.Entities.Concrete.Draw;

namespace Draw.DrawLayer.Concrete.Helpers
{
    public static class DrawMath
    {
        public static Point AdditionPointPlusXY(Point point,double distanceX, double distanceY)
        {
            return new Point { X = point.X + distanceX, Y = point.Y+distanceY, PointTypeId = point.PointTypeId };
        }
        public static Point AdditionPointPlusX(Point point, double distanceX)
        {
            return new Point { X = point.X+distanceX, Y = point.Y, PointTypeId = point.PointTypeId };
        }
        public static Point AdditionPointPlusY(Point point, double distanceY)
        {
            return new Point { X=point.X,Y=point.Y+distanceY,PointTypeId=point.PointTypeId};
        }

        public static double DifferancePointsX(Point point1, Point point2)
        {
            return Math.Abs(point1.X-point2.X);
        }

        public static double DifferancePointsY(Point point1, Point point2)
        {
            return Math.Abs(point1.Y - point2.Y);
        }

        public static double DifferanceTwoPoints(Point point1, Point point2)
        {
            var difX = DifferancePointsX(point1, point2);
            var difY = DifferancePointsY(point1, point2);
            var result = Math.Sqrt((difX * difX) +(difY * difY));
            return result;
        }

        public static Point FindBetweenPointToTwoPoint(Point p1,Point p2,int pointTypeId)
        {
            var x = (p1.X + p2.X) / 2;
            var y = (p1.Y + p2.Y) / 2;
            return new Point { X=x,Y=y,PointTypeId=pointTypeId};
        }

        public static (Point,double) FindCenterAndRadiusToTreePoint(Point p1, Point p2, Point p3)
        {
            double x1, y1, z1;
            x1 = p1.X;
            y1 = p1.Y;
            z1 = 1;
            double x2, y2, z2;
            x2 = p2.X;
            y2 = p2.Y;
            z2 = 1;
            double x3, y3, z3;
            x3 = p3.X;
            y3 = p3.Y;
            z3 = 1;
            var a1 = -(p1.X * p1.X) - (p1.Y * p1.Y);
            var a2 = -(p2.X * p2.X) - (p2.Y * p2.Y);
            var a3 = -(p3.X * p3.X) - (p3.Y * p3.Y);

            var m1 = new double[,] { { x1, y1, z1 }, { x2, y2, z2 },{ x3,y3,z3} };
            var m2 = new double[,] { { a1, y1, z1 }, { a2, y2, z2 },{ a3,y3,z3} };
            var m3 = new double[,] { { x1, a1, z1 }, { x2, a2, z2 },{ x3,a3,z3} };
            var m4 = new double[,] { { x1, y1, a1 }, { x2, y2, a2 },{ x3,y3,a3} };

            var d1 = CalculateDeterminant3x3(m1);
            var d2 = CalculateDeterminant3x3(m2);
            var d3 = CalculateDeterminant3x3(m3);
            var d4 = CalculateDeterminant3x3(m4);

            var D = d2 / d1;
            var E = d3 / d1;
            var F = d4 / d1;

            var Merkez = new Point { X = -D / 2, Y = -E / 2 };
            var Yaricap = (Math.Sqrt((double)(D*D) + (double)(E*E) - (double)(4 * F))) * 0.5;
            return (Merkez, Yaricap);
        }
        public static double CalculateDeterminant3x3(double[,] m33)
        {
            
            var d1 = m33[0, 0] * CalculateDeterminant2x2(new double[,] { 
                    { m33[1, 1], m33[1, 2] }, 
                    { m33[2, 1], m33[2, 2] } });
            var d2 = m33[0, 1] * CalculateDeterminant2x2(new double[,] {
                    { m33[1, 0], m33[1, 2] },
                    { m33[2, 0], m33[2, 0] } });
            var d3 = m33[0, 2] * CalculateDeterminant2x2(new double[,] {
                    { m33[1, 0], m33[1, 1] },
                    { m33[2, 0], m33[2, 1] } });

            return d1-d2+d3;
        }
        public static double CalculateDeterminant2x2(double[,] m22)
        {
            return (m22[0, 0] * m22[1,1]) - (m22[0, 1] * m22[1,0]);
        }
    }
}
