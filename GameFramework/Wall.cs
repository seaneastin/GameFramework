using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Wall : Entity
    {
        public Wall(int X, int Y, string imageName) : base('█', imageName) //come back to this later
        {
            x = X;
            y = Y;
            OriginX = 0;
            OriginY = 0;
            Solid = true;
            Icon = '█';
            OnUpdate += rotation;
        }
        public void rotation()
        {
            Rotate(.5f);
        }

    }
}
