using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{

    class Game
    {
        //whetehr or not the Game should finish running and exit
        public static bool Gameover = false;


        private static Scene _currentScene;
        public Game()
        {

        }

        private void Init()
        {
            Room startingRoom = new Room(10, 10);
            Room otherRoom = new Room(10, 10);
            Enemy enemy = new Enemy();
            otherRoom.Onstart += OtherRoomStart;
            void OtherRoomStart()
            {
                enemy.x = 2;
                enemy.y = 4;
            }
            startingRoom.North = otherRoom;
            otherRoom.South = otherRoom;
            startingRoom.South = otherRoom;
            startingRoom.West = otherRoom;
            startingRoom.East = otherRoom;


            startingRoom.AddEntity(new Wall(0, 0));
            startingRoom.AddEntity(new Wall(1, 4));
            startingRoom.AddEntity(new Wall(2, 4));
            startingRoom.AddEntity(new Wall(3, 2));
            //add a border
            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(i, otherRoom.SizeY));
                }
            }


            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(i, 0));
                }
            }

            for (int i = 0; i < otherRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(0, i));
                }
            }

            for (int i = 0; i < otherRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(otherRoom.SizeX - 1, i));
                }
            }



            startingRoom.AddEntity(new Wall(3, 2));
            startingRoom.AddEntity(new Wall(3, 2));
            startingRoom.AddEntity(new Wall(3, 2));

            startingRoom.AddEntity(new Wall(4, 3));
            startingRoom.AddEntity(new Wall(5, 3));
            Player player = new Player();
            otherRoom.AddEntity(_enemy);
            startingRoom.AddEntity(player);
            player.x = 1;
            player.y = 1;
            _currentScene = startingRoom;

        }

        public void Run()
        {
            Init();


            PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape);


            _currentScene.Start();

            //Loop until the game is over
            while (!Gameover)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }
        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
                _currentScene.Start();
            }
            set
            {
                _currentScene = value;
            }
        }
        public void Quit()
        {
            Gameover = true;
        }

        private Enemy _enemy = new Enemy();


            
    }
}
