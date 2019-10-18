using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class player : Entity
    {
        public player() : this('@')
        {

        }
        public player(char icon) : base(icon)
        {
            PlayerInput.AddKeyEvent(MoveRight, ConsoleKey.RightArrow);
            PlayerInput.AddKeyEvent(MoveLeft, ConsoleKey.LeftArrow);
            PlayerInput.AddKeyEvent(MoveUp, ConsoleKey.UpArrow);
            PlayerInput.AddKeyEvent(MoveDown, ConsoleKey.DownArrow);
        }



        //Move one space to the right
        private void MoveRight()
        {
            if (!MyScene.GetCollision(x + 1, y))
            {
                x++;
            }
        }
        private void MoveLeft()
        {
            
            if (!MyScene.GetCollision(x - 1, y))
            {
                x--;
            }
        }
        private void MoveUp()
        {
            
            if (!MyScene.GetCollision(x, y - 1))
                
            {
                y--;
            }

        }
        private void MoveDown()
        {
            
            if (!MyScene.GetCollision(x, y + 1))
            {
                y++;
            }
        }



    }
}
