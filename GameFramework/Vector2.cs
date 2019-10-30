using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector2
    {
        public float X, Y;


        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }


        public override string ToString()
        {
            return "{ " + X + ", " + Y + "}";
        }


        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }
        public static Vector2 operator /(float number, Vector2 rhs)
        {
            return new Vector2(number / rhs.X, number / rhs.Y);
        }
        public static Vector2 operator /(Vector2 lhs, float number)
        {
            return new Vector2(lhs.X / number, lhs.Y / number);
        }
        public static Vector2 operator *(float number, Vector2 rhs)
        {
            return new Vector2(number * rhs.X, number * rhs.Y);
        }
        public static Vector2 operator *(Vector2 lhs, float number)
        {
            return new Vector2(lhs.X * number, lhs.Y * number);
        }




        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y);
        }

        public float MagnitudeSqr()
        {
            return (X * X + Y * Y);
        }

        public float Distance(Vector2 other)
        {
            float diffX = X - other.X;
            float diffY = Y - other.Y;
            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        public void Normalize()
        {
            float m = Magnitude();
            this.X /= m;
            this.Y /= m;
        }

        public Vector2 GetNormalised()
        {
            return (this / Magnitude());
        }


        public float DotProduct(Vector2 other)
        {
            return ((X * other.X) + (Y * other.Y));
        }

        public float AngleBetween(Vector2 other)
        {
            Vector2 a = GetNormalised();
            Vector2 b = other.GetNormalised();

            float d = a.DotProduct(b);

            return (float)Math.Acos(d);
        }

    }
}
