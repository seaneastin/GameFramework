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
            x++;
            if (x > MyScene.SizeX-1)
            {
                x--;
            }
        }
        private void MoveLeft()
        {
            x--;
            if (x < 0)
            {
                x++;
            }
        }
        private void MoveUp()
        {
            y--;
            if (y < 0)
                
            {
                y++;
            }

        }
        private void MoveDown()
        {
            y++;
            if (y > MyScene.SizeX - 1)
            {
                y--;
            }
        }



    }
}
