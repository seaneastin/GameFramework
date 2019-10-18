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

    }
}
