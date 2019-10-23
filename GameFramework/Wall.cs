using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Wall : Entity
    {
        public Wall(int X, int Y) : base("█" , "/images/ezgif/tile012.png")
        {
            x = X;
            y = Y;
            Solid = true;
            Icon = '█';
        }
    }
}
