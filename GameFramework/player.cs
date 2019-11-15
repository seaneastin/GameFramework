using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Player : Entity
    {
        private PlayerInput _input = new PlayerInput();
        private Entity _sword = new Entity('/', "imges/ezgif/tile012.png");


        public Entity Sword
        {
            get { return _sword; }
        }
        public Player() : this('@') //add player image
        {

        }

        public Player(string imageName) : base('@', imageName)
        {
            _input.AddKeyEvent(MoveRight, 100); //D 
            _input.AddKeyEvent(MoveLeft, 97); //A
            _input.AddKeyEvent(MoveUp, 119); //W
            _input.AddKeyEvent(MoveDown, 115); //S
            _input.AddKeyEvent(detachSword, 69); //nice
            _input.AddKeyEvent(AttachSword, 101);
            //Add ReadKey to this Entity's OnUpdate
            OnUpdate += _input.ReadKey;
            OnUpdate += rotation;
            OnUpdate += Orbit;
            Onstart += CreateSword;
            Onstart += AttachSword;
        }

        public Player(char icon) : base(icon)
        {

        }



        //Move one space to the right
        private void MoveRight()
        {
            if (x + 1> MyScene.SizeX - 1)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.East);
                }
                x = 0;
                    
            }



            else if (!MyScene.GetCollision(x + 1, y))
            {
                x++;
            }
        }


        private void Orbit(float deltaTime)
        {
            foreach (Entity child in _children)
            {
                // child.Rotate(.4f * deltaTime);
            }
            Rotate(.4f);
        }


        private void CreateSword()
        {
            MyScene.AddEntity(_sword);
            _sword.x = x;
            _sword.y = y;
        }

        private void AttachSword()
        {
            if (!Hitbox.Overlaps(_sword.Hitbox))
                {
                return;
            }
            _sword.x = .5f;
            _sword.y = .5f;
            //_sword.x++;
            AddChild(_sword);
        }




        private void detachSword()
        {
            RemoveChild(_sword);
        }


        private void MoveLeft()
        {
            if (x - 1 < 0)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.West);
                }
                x = MyScene.SizeX - 1;
            }


            else if (!MyScene.GetCollision(x - 1, y)) 
            {
                x--;
            }




        }
        private void MoveUp()
        {
            if (y - 1 < 0)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.North);

                }

                y = MyScene.SizeY - 1;




            }
            
            else if (!MyScene.GetCollision(x, y - 1))
                
            {
                y--;

            }

        }
        private void MoveDown()
        {
            if (y + 1 > MyScene.SizeY - 1)
            {
                if (MyScene is Room)
                {
                    Room Dest = (Room)MyScene;
                    Travel(Dest.South);
                }
                y = 0;
            }


            else if (!MyScene.GetCollision(x, y + 1))
            {
                y++;
            }
        }
        //move the player to the desistination room and change the Scene
        private void Travel(Scene destination)
        {
            if (destination == null)
            {
                return;
            }
            if (_sword.Parent == this)
            {
                MyScene.RemoveEntity(_sword);
                destination.AddEntity(_sword);
            }


            MyScene.RemoveEntity(this);
            destination.AddEntity(this);
            Game.CurrentScene = destination;
        }

        public void rotation(float deltaTime)
        {
          //  Rotate(.05f);
        }


        


    }
}
