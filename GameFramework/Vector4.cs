using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector4
    {
        float X, Y, Z, W;


        public Vector4()
        {
            X = 0;
            Y = 0;
            Z = 0;
            W = 0;
        }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }


        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z, lhs.W + rhs.W);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z, lhs.W - rhs.W);
        }
        public static Vector4 operator /(float number, Vector4 rhs)
        {
            return new Vector4(number / rhs.X, number / rhs.Y, number / rhs.Z, number / rhs.W);
        }
        public static Vector4 operator /(Vector4 lhs, float number)
        {
            return new Vector4(lhs.X / number, lhs.Y / number, lhs.Z / number, lhs.W / number);
        }
        public static Vector4 operator *(float number, Vector4 rhs)
        {
            return new Vector4(number * rhs.X, number * rhs.Y, number * rhs.Z, number + rhs.W);
        }
        public static Vector4 operator *(Vector4 lhs, float number)
        {
            return new Vector4(lhs.X * number, lhs.Y * number, lhs.Z * number, lhs.W + number);
        }


        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public float MagnitudeSqr()
        {
            return (X * X + Y * Y + Z * Z);
        }

        public float Distance(Vector4 other)
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

        public Vector4 GetNormalised()
        {
            return (this / Magnitude());
        }



    }
}

