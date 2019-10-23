using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Enemy : Entity
    {

        private Direction _facing;
        
        public Enemy() 
        {

        } 

        public Enemy(char icon, string imageName) : base (icon, imageName)
        {
            _facing = Direction.North;
            OnUpdate += Move;
        }

        private void TouchPlayer()
        {
            List<Entity> touched;
            touched = MyScene.GetEntities(x, y);
            bool hit = false;
            foreach (Entity e in touched)
            {
                if (e is Player)
                {
                    hit = true;
                    break;
                }

            }
            if (hit)
            {
                MyScene.RemoveEntity(this);
            }
        }

            public void Move()
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUP();
                    break;
                case Direction.South:
                    MoveDown();
                    break;
                case Direction.East:
                    MoveLeft();
                    break;
                case Direction.West:
                    MoveRight();
                    break;

            }
        }

        public void MoveDown()
        {
            if (!MyScene.GetCollision(x, y + 1))
            {
                y++;
            }
            else
            {
                _facing = Direction.North;
            }
        }

        public void MoveUP()
        {
            if (!MyScene.GetCollision(x, y - 1))

            {
                y--;

            }
            else
            {
                _facing = Direction.South;
            }
            
        }

        public void MoveLeft()
        {
            if (!MyScene.GetCollision(x - 1, y))
            {
                x--;
            }
            else
            {
                _facing = Direction.South;
            }
        }

        public void MoveRight()
        {
            if (!MyScene.GetCollision(x + 1, y))
            {
                x++;
            }
            else
            {
                _facing = Direction.South;
            }
        }



    }
}
