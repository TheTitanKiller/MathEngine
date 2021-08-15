using System;

namespace MathEngine
{
    public struct Point2D : IEquatable<Point2D>
    {
        public double X { get; init; }
        public double Y { get; init; }

        public Point2D(double x, double y) => (X, Y) = (x, y);

        public double Distance(Point2D other)
        {
            double distX = other.X - X;
            double distY = other.Y - Y;
            return Math.Sqrt((distX * distX) + (distY * distY));
        }

        public bool Equals(Point2D other) => (other.X, other.Y) == (X, Y);

        public override bool Equals(object obj) => obj is Point2D point && Equals(point);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point2D left, Point2D right) => left.Equals(right);

        public static bool operator !=(Point2D left, Point2D right) => !(left == right);
    }
}
