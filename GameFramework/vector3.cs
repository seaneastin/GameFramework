using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector3
    {
        public float X, Y, Z;

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z));
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.X, a.Y), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z));
        }

        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            return Max(a, Min(b, t));
        }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public override string ToString()
        {
            return "{ " + X + ", " + Y + "," + Z + "}";
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }
        public static Vector3 operator /(float number, Vector3 rhs)
        {
            return new Vector3(number / rhs.X, number / rhs.Y, number / rhs.Z);
        }
        public static Vector3 operator /(Vector3 lhs, float number)
        {
            return new Vector3(lhs.X / number, lhs.Y / number, lhs.Z / number);
        }
        public static Vector3 operator *(float number, Vector3 rhs)
        {
            return new Vector3(number * rhs.X, number * rhs.Y, number * rhs.Z);
        }
        public static Vector3 operator *(Vector3 lhs, float number)
        {
            return new Vector3(lhs.X * number, lhs.Y * number, lhs.Z * number);
        }


        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public float MagnitudeSqr()
        {
            return (X * X + Y * Y + Z * Z);
        }

        public float Distance(Vector3 other)
        {
            float diffX = X - other.X;
            float diffY = Y - other.Y;
            float diffZ = Z - other.Z;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }

        public void Normalize()
        {
            float m = Magnitude();
            this.X /= m;
            this.Y /= m;
            this.Z /= m;
        }

        public Vector3 GetNormalised()
        {
            return (this / Magnitude());
        }

        public float DotProduct(Vector3 other)
        {
            return ((X * other.X) + (Y * other.Y) + (Z * other.Z));
        }

        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3 (Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
        }


        public float AngleBetween(Vector3 other)
        {
            Vector3 a = GetNormalised();
            Vector3 b = other.GetNormalised();

            float d = a.DotProduct(b);

            return (float)Math.Acos(d);
        }


    }
}
