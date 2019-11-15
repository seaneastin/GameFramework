using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class AABB
    {
        private Vector3 _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        private Vector3 _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);


        public AABB()
        {

        }



        public AABB(Vector3 _min, Vector3 _max)
        {
            this._min = _min;
            this._max = _max;
        }

        public void Move(Vector3 point)
        {
            Vector3 extents = Extents();
            _min = point - extents;
            _max = point + extents;
        }

        public Vector3 Center()
        {
            return (_min + _max * 0.5f);
        }


        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(_max.X - _min.X) * 0.5f, Math.Abs(_max.Y - _min.Y) * 0.5f, Math.Abs(_max.Z - _min.Z) * 0.5f);
        }



        public List<Vector3> Corners()
        {
            List<Vector3> corners = new List<Vector3>(4);
            corners[0] = _min; //top left
            corners[1] = new Vector3(_min.X, _max.Y, _min.Z); //bottom left
            corners[2] = _max; //bottom right
            corners[3] = new Vector3(_max.X, _min.Y, _min.Z); //bottom right
            return corners;


        }





        public void Fit(List<Vector3> points)
        {
            _min = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

            _max = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);


            foreach (Vector3 p in points)
            {
                _min = Vector3.Min(_min, p);
                _max = Vector3.Max(_max, p);
            }
        }


        public bool Overlaps(Vector3 p)
        {
            return !(p.X < _min.X || p.Y < _min.Y || p.X > _max.X || p.Y > _max.Y);
        }

        public bool Overlaps(AABB other)
        {
            return !(_max.X < other._min.X || _max.Y < other._min.Y || _min.X > other._max.X || _min.Y > other._max.Y);
        }


        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, _min, _max);
        }

        public void Draw(Color color)
        {
            float posX = _min.X * Game.UnitSize.X + Game.UnitSize.X /2;
            float posY = _min.Y * Game.UnitSize.Y + Game.UnitSize.Y / 2;
            float width = (_max.X - _min.X) * Game.UnitSize.X;
            float height = (_max.Y - _min.Y) * Game.UnitSize.Y;
            RL.DrawRectangleLines((int)posX, (int)posY, (int)width, (int)height, color);
        }
    }
}
