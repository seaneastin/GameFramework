using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Player : Entity
    {
        public Player() : this('@')
        {

        }

        public Player(string imageName) : base('@', imageName)
        {
            PlayerInput.AddKeyEvent(MoveRight, 100); //D 
            PlayerInput.AddKeyEvent(MoveLeft, 97); //A
            PlayerInput.AddKeyEvent(MoveUp, 119); //W
            PlayerInput.AddKeyEvent(MoveDown, 115); //S
        }

        public Player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveRight, 100); //D 
            PlayerInput.AddKeyEvent(MoveLeft, 97); //A
            PlayerInput.AddKeyEvent(MoveUp, 119); //W
            PlayerInput.AddKeyEvent(MoveDown, 115); //S
        }



        //Move one space to the right
        private void MoveRight()
        {
            if (x + 1> MyScene.SizeX - 1)
            {
                Room Dest = (Room)MyScene;
                Travel(Dest.East);
                x = 0;
            }



            else if (!MyScene.GetCollision(x + 1, y))
            {
                x++;
            }
        }




        private void MoveLeft()
        {
            if (x - 1 < 0)
            {
                Room Dest = (Room)MyScene;
                Travel(Dest.West);
                
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

    }
}
