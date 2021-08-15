using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine
{
    public struct Point4D : IEquatable<Point4D>
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public double T { get; init; }

        public Point4D(double x, double y, double z, double t) => (X, Y, Z, T) = (x, y, z, t);

        public double Distance(Point4D other)
        {
            double distX = other.X - X;
            double distY = other.Y - Y;
            double distZ = other.Z - Z;
            double distT = other.T - T;
            return Math.Sqrt((distX * distX) + (distY * distY) + (distZ * distZ) + (distT * distT));
        }

        public bool Equals(Point4D other) => (other.X, other.Y, other.Z, other.T) == (X, Y, Z, T);

        public override bool Equals(object obj) => obj is Point4D point && Equals(point);

        public override int GetHashCode() => HashCode.Combine(X, Y, Z, T);

        public static bool operator ==(Point4D left, Point4D right) => left.Equals(right);

        public static bool operator !=(Point4D left, Point4D right) => !(left == right);

        public static implicit operator Point2D(Point4D point) => new(point.X, point.Y);
        public static implicit operator Point3D(Point4D point) => new(point.X, point.Y, point.Z);
        public static implicit operator Point4D(Point2D point) => new(point.X, point.Y, 0, 0);
        public static implicit operator Point4D(Point3D point) => new(point.X, point.Y, point.Z, 0);
    }
}
