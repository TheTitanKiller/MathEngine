using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine
{
    public struct Vector4 : IEquatable<Vector4>
    {
        public static readonly Vector4 Zero = new(0, 0, 0, 0);
        public static readonly Vector4 One = new(1, 1, 1, 1);
        public static readonly Vector4 Up = new(0, 1, 0, 0);
        public static readonly Vector4 Down = new(0, -1, 0, 0);
        public static readonly Vector4 Right = new(1, 0, 0, 0);
        public static readonly Vector4 Left = new(-1, 0, 0, 0);
        public static readonly Vector4 Forward = new(0, 0, 1, 0);
        public static readonly Vector4 Back = new(0, 0, -1, 0);
        public static readonly Vector4 Ana = new(0, 0, 0, 1);
        public static readonly Vector4 Kata = new(0, 0, 0, -1);

        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public double T { get; init; }
        public double Magnitude { get; init; }

        public Vector4(Point4D x, Point4D y) => (X, Y, Z, T, Magnitude) = (y.X - x.X, y.Y - x.Y, y.Z - x.Z, y.T - x.T, y.Distance(x));

        public Vector4(double x, double y, double z, double t) => (X, Y, Z, T, Magnitude) = (x, y, z, t, Math.Sqrt(x * x + y * y + z * z + t * t));

        public Vector4 Normalize() => this / Magnitude;

        public double Dot(Vector4 other) => X * other.X + Y * other.Y + Z * other.Z + T * other.T;

        public bool Equals(Vector4 other) => (other.X, other.Y, other.Z, other.T) == (X, Y, Z, T);

        public override bool Equals(object obj) => obj is Vector4 vector && Equals(vector);

        public override int GetHashCode() => HashCode.Combine(X, Y, Z, T);

        public static bool operator ==(Vector4 left, Vector4 right) => left.Equals(right);

        public static bool operator !=(Vector4 left, Vector4 right) => !(left == right);

        public static Vector4 operator +(Vector4 left, Vector4 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.T + right.T);

        public static Vector4 operator -(Vector4 left, Vector4 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.T - right.T);

        public static Vector4 operator *(double left, Vector4 right) => new(left * right.X, left * right.Y, left * right.Z, left * right.T);

        public static Vector4 operator *(Vector4 left, double right) => right * left;

        public static Vector4 operator /(Vector4 left, double right) => 1 / right * left;

        public static implicit operator Vector2(Vector4 vector) => new(vector.X, vector.Y);
        public static implicit operator Vector3(Vector4 vector) => new(vector.X, vector.Y, 0);
        public static implicit operator Vector4(Vector2 vector) => new(vector.X, vector.Y, 0, 0);
        public static implicit operator Vector4(Vector3 vector) => new(vector.X, vector.Y, vector.Z, 0);

        public override string ToString() => $"Vector4({X}, {Y}, {Z}, {T})";
    }
}
