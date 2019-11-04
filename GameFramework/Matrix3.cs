using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Matrix3
    {

        public static Matrix3 identity = new Matrix3();

        public float m11, m12, m13, m21, m22, m23, m31, m32, m33;

        public override string ToString()
        {
            return "{ " + m11 + ", " + m12 + ", " + m13 +
                "\n"  + m21 + ", " + m22 + ", " + m23 + 
                "\n" + m31 + ", " + m32 + ", " + m33 + "}";
        }

        //sets the matrix3 to the specified values
        public void Set(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public Matrix3()
        {
            m11 = 1; m12 = 0; m13 = 0;
            m21 = 0; m22 = 1; m23 = 0;
            m31 = 0; m32 = 0; m33 = 1;
        }


        public Matrix3(float m11, float m12, float m13, float m21, float m22, float m23, float m31 , float m32, float m33)
        {
            this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public Matrix3(Matrix3 other)
        {


        }

        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs) 
        {
            return new Matrix3(
        lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
        lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32, //first line of matrix
        lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,


        lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
        lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32, //second line of matrix
        lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,


        lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
        lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32, //third line of matrix
        lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33);



        }

        public static Vector2 operator *(Matrix3 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.m11 * rhs.X + lhs.m12 * rhs.Y,
                lhs.m21 + rhs.X + lhs.m22 * rhs.Y);      
        }


        public void SetScaled(float x, float y, float z)
        {
            m11 = x; m12 = 0; m13 = 0;
            m21 = 0; m22 = y; m23 = 0;
            m31 = 0; m32 = 0; m33 = z;
        }

        public void SetScaled(Vector3 v)
        {
            m11 = v.X ; m12 = 0; m13 = 0;
            m21 = 0; m22 = v.Y; m23 = 0;
            m31 = 0; m32 = 0; m33 = v.Z;
        }

        public void Scale(Vector3 v)
        {
            Matrix3 m = new Matrix3();
            m.SetScaled(v.X, v.Y, v.Z);

            Set(this * m);
        }



        public void SetRotateX(double radians)
        {
            Set(1, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians));
        }

        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);
            Set(this * m);
        }

        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0, 1, 0, (float)-Math.Sin(radians), 0, (float)Math.Cos(radians));
        }

        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);
            Set(this * m);
        }

        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0, 0, 1, 0, 0, (float)-Math.Cos(radians));
        }


        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);


            // combine rotations in a specific order
            Set(z * y * x);
        }


        public void SetTranslation(float x, float y, float z)
        {
            m13 = x; m23 = y; m33 = z;
        }


        public void Translate(float x, float y, float z)
        {
            m13 += x; m23 += y; m33 = z;
        }

        public void Set(Matrix3 scaled)
        {
            scaled.m11 = m11; scaled.m12 = m12; scaled.m13 = m13;
            scaled.m21 = m21; scaled.m22 = m22; scaled.m23 = m23;
            scaled.m31 = m31; scaled.m32 = m32; scaled.m33 = m33;
        }


        public static Vector3 operator *(Matrix3 lhs, Vector3 rhs)
        {
            return new Vector3(
             lhs.m11 * rhs.X + lhs.m12 * rhs.Y + lhs.m13 * rhs.Z,
             lhs.m21 * rhs.X + lhs.m22 * rhs.Y + lhs.m23 * rhs.Z,
             lhs.m31 * rhs.X + lhs.m32 * rhs.Y + lhs.m32 * rhs.Z);
                
                
                
                
        }
           

    }

    

}
