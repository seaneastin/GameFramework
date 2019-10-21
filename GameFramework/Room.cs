using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    enum Direction
    {
        North,
        South,
        East,
        West
    }




    class Room : Scene
    {




        //Rooms connected to this one
        private Room _north;
        private Room _south;
        private Room _east;
        private Room _west;

        public Room() : this(12, 6)
        {

        }
        public Room(int sizeX, int sizeY) : base(sizeX, sizeY)
        {

        }

        public Room North
        {
            get
            {
                return _north;
            }
            set
            {
                _north = value;
                /* if (value!= null)
                 {
                     value._south = this;
                 }
                 else
                 {
                     _north._south = null;
                 }
                 */
                value._south = this;
            }
        }
        public Room South
        {
            get
            {
                return _south;
            }
            set
            {
                _south = value;
                value._north = this;
            }
        }
        public Room East
        {
            get
            {
                return _east;
            }
            set
            {
                _east = value;
                value._west = this;
            }
        }
        public Room West
        {
            get
            {
                return _west;
            }
            set
            {
                _west = value;
                value._east = this;
            }
        }

    }
}
