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
            Solid = true;
            Icon = '█';
        }
    }
}
