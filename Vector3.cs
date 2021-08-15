using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public static readonly Vector3 Zero = new(0, 0, 0);
        public static readonly Vector3 One = new(1, 1, 1);
        public static readonly Vector3 Up = new(0, 1, 0);
        public static readonly Vector3 Down = new(0, -1, 0);
        public static readonly Vector3 Right = new(1, 0, 0);
        public static readonly Vector3 Left = new(-1, 0, 0);
        public static readonly Vector3 Forward = new(0, 0, 1);
        public static readonly Vector3 Back = new(0, 0, -1);

        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }
        public double Magnitude { get; init; }

        public Vector3(Point3D x, Point3D y) => (X, Y, Z, Magnitude) = (y.X - x.X, y.Y - x.Y, y.Z - x.Z, y.Distance(x));

        public Vector3(double x, double y, double z) => (X, Y, Z, Magnitude) = (x, y, z, Math.Sqrt(x * x + y * y + z * z));

        public Vector3 Normalize() => this / Magnitude;

        public double Dot(Vector3 other) => X * other.X + Y * other.Y + Z * other.Z;

        public bool Equals(Vector3 other) => (other.X, other.Y, other.Z) == (X, Y, Z);

        public override bool Equals(object obj) => obj is Vector3 vector && Equals(vector);

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public static bool operator ==(Vector3 left, Vector3 right) => left.Equals(right);

        public static bool operator !=(Vector3 left, Vector3 right) => !(left == right);

        public static Vector3 operator +(Vector3 left, Vector3 right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static Vector3 operator -(Vector3 left, Vector3 right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static Vector3 operator *(double left, Vector3 right) => new(left * right.X, left * right.Y, left * right.Z);

        public static Vector3 operator *(Vector3 left, double right) => right * left;

        public static Vector3 operator /(Vector3 left, double right) => 1 / right * left;

        public static implicit operator Vector2(Vector3 vector) => new(vector.X, vector.Y);
        public static implicit operator Vector3(Vector2 vector) => new(vector.X, vector.Y, 0);
    }
}
