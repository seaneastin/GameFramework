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
        public float Speed { get; set; } = .30f;
        
        public Enemy() 
        {

        } 

        public Enemy(char icon, string imageName) : base (icon, imageName)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
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
           // Rotate(.05f);
            //Scale = 2f;
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
            if (!MyScene.GetCollision(XAbsolute, Sprite.Bottom + Speed))
            {
                yVelocity = Speed;
            }
            else
            {
                yVelocity = 0f;
                _facing = Direction.East;
            }
        }

        public void MoveUP()
        {
            if (!MyScene.GetCollision(XAbsolute, Sprite.Top - Speed))

            {
                yVelocity = -Speed;

            }
            else
            {
                yVelocity = 0f;
                _facing = Direction.South;
            }
            
        }

        public void MoveLeft()
        {
            if (!MyScene.GetCollision(YAbsolute, Sprite.Left - Speed))
            {
                xVelocity = -Speed;
            }
            else
            {
                xVelocity = 0f;
                _facing = Direction.West;
            }
        }

        public void MoveRight()
        {
            if (!MyScene.GetCollision(YAbsolute, Sprite.right + Speed))
            {
                xVelocity = Speed;
            }
            else
            {
                xVelocity = 0f;
                _facing = Direction.North;
            }
        }



    }
}
