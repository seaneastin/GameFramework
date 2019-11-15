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
        private float _speed = 5f;
        public float Speed {
            get
            {
                return _speed;
            }


            set
            {
             _speed = value;
            }
        }
        
        

        public Enemy() 
        {

        } 

        public Enemy(char icon, string imageName) : base (icon, imageName)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        private void TouchPlayer(float deltaTime)
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

            public void Move(float deltaTime)
        {
           // Rotate(.05f);
            //Scale = 2f;
            switch (_facing)
            {
                case Direction.North:
                    MoveUP(deltaTime);
                    break;
                case Direction.South:
                    MoveDown(deltaTime);
                    break;
                case Direction.East:
                    MoveLeft(deltaTime);
                    break;
                case Direction.West:
                    MoveRight(deltaTime);
                    break;

            }
        }

        public void MoveDown(float deltaTime)
        {
            if (!MyScene.GetCollision(XAbsolute, Sprite.Bottom + Speed * deltaTime))
            {
                yVelocity = Speed * deltaTime;
            }
            else
            {
                yVelocity = 0f;
                _facing = Direction.East;
            }
        }

        public void MoveUP(float deltaTime)
        {
            if (!MyScene.GetCollision(XAbsolute, Sprite.Top - Speed * deltaTime))

            {
                yVelocity = -Speed * deltaTime;

            }
            else
            {
                yVelocity = 0f;
                _facing = Direction.South;
            }
            
        }

        public void MoveLeft(float deltaTime)
        {
            if (!MyScene.GetCollision(YAbsolute, Sprite.Left - Speed * deltaTime))
            {
                xVelocity = -Speed * deltaTime;
            }
            else
            {
                xVelocity = 0f;
                _facing = Direction.West;
            }
        }

        public void MoveRight(float deltaTime)
        {
            if (!MyScene.GetCollision(YAbsolute, Sprite.right + Speed * deltaTime))
            {
                xVelocity = Speed * deltaTime;
            }
            else
            {
                xVelocity = 0f;
                _facing = Direction.North;
            }
        }



    }
}
