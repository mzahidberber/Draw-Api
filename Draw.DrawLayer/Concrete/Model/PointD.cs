﻿namespace Draw.DrawLayer.Concrete.Model
{
    public struct PointD
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public PointD(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
