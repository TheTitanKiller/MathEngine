using System;

namespace MathEngine
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public static readonly Vector2 Zero = new(0, 0);
        public static readonly Vector2 One = new(1, 1);
        public static readonly Vector2 Up = new(0, 1);
        public static readonly Vector2 Down = new(0, -1);
        public static readonly Vector2 Right = new(1, 0);
        public static readonly Vector2 Left = new(-1, 0);

        public double X { get; init; }
        public double Y { get; init; }
        public double Magnitude { get; init; }

        public Vector2(Point2D x, Point2D y) => (X, Y, Magnitude) = (y.X - x.X, y.Y - x.Y, y.Distance(x));

        public Vector2(double x, double y) => (X, Y, Magnitude) = (x, y, Math.Sqrt(x * x + y * y));

        public Vector2 Normalize() => this / Magnitude;

        public double Dot(Vector2 other) => X * other.X + Y * other.Y;

        public bool Equals(Vector2 other) => (other.X, other.Y) == (X, Y);

        public override bool Equals(object obj) => obj is Vector2 vector && Equals(vector);

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Vector2 left, Vector2 right) => left.Equals(right);

        public static bool operator !=(Vector2 left, Vector2 right) => !(left == right);

        public static Vector2 operator +(Vector2 left, Vector2 right) => new(left.X + right.X, left.Y + right.Y);

        public static Vector2 operator -(Vector2 left, Vector2 right) => new(left.X - right.X, left.Y - right.Y);

        public static Vector2 operator *(double left, Vector2 right) => new(left * right.X, left * right.Y);

        public static Vector2 operator *(Vector2 left, double right) => right * left;

        public static Vector2 operator /(Vector2 left, double right) => 1 / right * left;

        public override string ToString() => $"Vector2({X}, {Y})";
    }
}
