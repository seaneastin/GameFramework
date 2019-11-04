using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Matrix4
    {

        public static Matrix4 identity = new Matrix4();

        public float m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44;

        public override string ToString()
        {
            return "{ " + m11 + ", " + m12 + ", " + m13 +
                "\n" + m21 + ", " + m22 + ", " + m23 +
                "\n" + m31 + ", " + m32 + ", " + m33 + "}";
        }

        //sets the matrix3 to the specified values
        public void Set(float m11, float m12, float m13, float m14, float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
            this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
            this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
            this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
        }

        public Matrix4()
        {
            m11 = 1; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = 1; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = 1; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }


        public Matrix4(float m11, float m12, float m13, float m14 , float m21, float m22, float m23, float m24, float m31, float m32, float m33, float m34, float m41, float m42, float m43, float m44)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
            this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
            this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
            this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
        }

        public Matrix4(Matrix4 other)
        {


        }

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
        lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31 + lhs.m14 * rhs.m41,
        lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32 + lhs.m14 * rhs.m42,                   //first line of matrix
        lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33 + lhs.m14 * rhs.m43,
        lhs.m11 * rhs.m14 + lhs.m12 * rhs.m24 + lhs.m13 * rhs.m34 + lhs.m14 * rhs.m44,

        lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31 + lhs.m24 * rhs.m41,
        lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32 + lhs.m24 * rhs.m42,                   //second line of matrix
        lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33 + lhs.m24 * rhs.m43,
        lhs.m21 * rhs.m14 + lhs.m22 * rhs.m24 + lhs.m23 * rhs.m34 + lhs.m24 * rhs.m44,

        lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31 + lhs.m34 * rhs.m41,
        lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32 + lhs.m34 * rhs.m42,                   //third line of matrix
        lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33 + lhs.m34 * rhs.m43,
        lhs.m31 * rhs.m14 + lhs.m32 * rhs.m24 + lhs.m33 * rhs.m34 + lhs.m34 * rhs.m44,


        lhs.m41 * rhs.m11 + lhs.m42 * rhs.m21 + lhs.m43 * rhs.m31 + lhs.m44 * rhs.m41,
        lhs.m41 * rhs.m12 + lhs.m42 * rhs.m22 + lhs.m43 * rhs.m32 + lhs.m44 * rhs.m42,                   //third line of matrix
        lhs.m41 * rhs.m13 + lhs.m42 * rhs.m23 + lhs.m43 * rhs.m33 + lhs.m44 * rhs.m43,
        lhs.m41 * rhs.m14 + lhs.m42 * rhs.m24 + lhs.m43 * rhs.m34 + lhs.m44 * rhs.m44);




        }

        public static Vector2 operator *(Matrix4 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.m11 * rhs.X + lhs.m12 * rhs.Y,
                lhs.m21 + rhs.X + lhs.m22 * rhs.Y);
        }


        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = y; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = z; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        public void SetScaled(Vector4 v)
        {
            m11 = v.X; m12 = 0; m13 = 0; m14 = 0;
            m21 = 0; m22 = v.Y; m23 = 0; m24 = 0;
            m31 = 0; m32 = 0; m33 = v.Z; m34 = 0;
            m41 = 0; m42 = 0; m43 = 0; m44 = 1;
        }

        public void SetTranslation(float x, float y, float z)
        {
            m41 = z; m42 = y; m43 = z; m44 = 1;
        }


        public void Translate(float x, float y, float z)
        {
            m41 += z; m42 += y; m43 = z; 
        }


        

    }
}
