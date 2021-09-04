using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine
{
    public struct Point3D : IEquatable<Point3D>
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }

        public Point3D(double x, double y, double z) => (X, Y, Z) = (x, y, z);

        public double Distance(Point3D other)
        {
            double distX = other.X - X;
            double distY = other.Y - Y;
            double distZ = other.Z - Z;
            return Math.Sqrt((distX * distX) + (distY * distY) + (distZ * distZ));
        }

        public bool Equals(Point3D other) => (other.X, other.Y, other.Z) == (X, Y, Z);

        public override bool Equals(object obj) => obj is Point3D point && Equals(point);

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public static bool operator ==(Point3D left, Point3D right) => left.Equals(right);

        public static bool operator !=(Point3D left, Point3D right) => !(left == right);

        public static implicit operator Point2D(Point3D point) => new(point.X, point.Y);
        public static implicit operator Point3D(Point2D point) => new(point.X, point.Y, 0);

        public override string ToString() => $"Point3D({X}, {Y}, {Z})";
    }
}
