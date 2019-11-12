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
        private Entity _sword2 = new Entity('/', "imges/ezgif/tile012.png");
        private Entity _sword3 = new Entity('/', "imges/ezgif/tile012.png");
        private Entity _sword4 = new Entity('/', "imges/ezgif/tile012.png");
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
            _input.AddKeyEvent(AttachSword, );
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


        private void Orbit()
        {
            foreach (Entity child in _children)
            {
                child.Rotate(.4f);
            }
            Rotate(.4f);
        }


        private void CreateSword()
        {
            
            AddChild(_sword);
            
            AddChild(_sword2);
            
            AddChild(_sword3);
            
            AddChild(_sword4);
        }

        private void AttachSword()
        {
            _sword.x = .5f;
            //_sword.x++;
            MyScene.AddEntity(_sword);


            _sword2.x = -.5f;
            //_sword2.x--; 
            MyScene.AddEntity(_sword2);

            _sword3.y = .5f;
            //_sword3.y++;
            MyScene.AddEntity(_sword3);



            _sword4.y = -.5f;
            //_sword4.y--;
            MyScene.AddEntity(_sword4);
        }




        private void detachSword()
        {
            RemoveChild(_sword);
            RemoveChild(_sword2);
            RemoveChild(_sword3);
            RemoveChild(_sword4);
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
            
            MyScene.RemoveEntity(this);
            destination.AddEntity(this);
            Game.CurrentScene = destination;
        }

        public void rotation()
        {
          //  Rotate(.05f);
        }



    }
}
