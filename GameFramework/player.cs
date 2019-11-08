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



        public Player() : this('@') //add player image
        {

        }

        public Player(string imageName) : base('@', imageName)
        {
            _input.AddKeyEvent(MoveRight, 100); //D 
            _input.AddKeyEvent(MoveLeft, 97); //A
            _input.AddKeyEvent(MoveUp, 119); //W
            _input.AddKeyEvent(MoveDown, 115); //S
            //Add ReadKey to this Entity's OnUpdate
            OnUpdate += _input.ReadKey;
            OnUpdate += rotation;
            OnUpdate += Orbit;
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
                //child.Rotate(1f);
            }
            Rotate(1.0f);
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
