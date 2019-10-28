﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector3
    {
        float X, Y, Z;


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



    }
}
