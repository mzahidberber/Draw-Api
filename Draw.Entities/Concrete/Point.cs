﻿using Draw.Entities.Abstract;

namespace Draw.Entities.Concrete
{
    public class Point : IEntity
    {
        public int PointId { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }

        public int ElementId { get; set; }
        public Element Element { get; set; } = null!;

        public int PointTypeId { get; set; }
        public PointType PointType { get; set; } = null!;
    }
}