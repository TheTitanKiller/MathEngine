using System;

namespace MathEngine
{
    public struct Point : IEquatable<Point>
    {
        public static readonly Point Zero = new(0, 0);

        public double X { get; init; }
        public double Y { get; init; }

        public Point(double x, double y) => (X, Y) = (x, y);

        public double Distance(Point other)
        {
            double distX = other.X - X;
            double distY = other.Y - Y;
            return Math.Sqrt((distX * distX) + (distY * distY));
        }

        public bool Equals(Point other) => (other.X, other.Y) == (X, Y);

        public override bool Equals(object obj) => obj is Point point && Equals(point);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point left, Point right) => left.Equals(right);

        public static bool operator !=(Point left, Point right) => !(left == right);
    }
}
