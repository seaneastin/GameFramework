using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Matrix2
    {

        public static Matrix2 identity = new Matrix2();

        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;


        public Matrix2()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }


        public Matrix2(float m11, float m12, float m13, float m21, float m22, float m23, float m31 )
        {
            this.m11 = 1; this.m12 = 0; this.m13 = 0;
            this.m21 = 0; this.m22 = 1; this.m23 = 0;
            this.m31 = 0; this.m32 = 0; this.m33 = 1;
        }

        public static Matrix2 operator *(Matrix2 lhs, Matrix2 rhs)
        {
            return new Matrix2(
        lhs.m11 * rhs
        }

        public static Vector2 operator *(Matrix2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.m11 * rhs.X + lhs.m12 * rhs.Y,
                lhs.m21 + rhs.X + lhs.m22 * rhs.Y);
        }


    }

}
