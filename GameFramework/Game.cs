using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{

    class Game
    {
        public static readonly int SizeX = 16;
        public static readonly int SizeY = 16;
        //whetehr or not the Game should finish running and exit
        public static bool Gameover = false;
        private Camera3D _camera;


        private static Scene _currentScene;

        private static Scene _nextScene;
        public Game()
        {
            RL.InitWindow(640, 480, "RPG Game");
            RL.SetTargetFPS(15);


            Raylib.Vector3 cameraPosition = new Raylib.Vector3(-10, -10, -10);
            Raylib.Vector3 cameraTarget = new Raylib.Vector3(0, 0, 0);
            Raylib.Vector3 cameraUp = new Raylib.Vector3(0, 0, 1);




            _camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);
        }




        private void Init()
        {
            Room startingRoom = new Room(10, 10);
            Room otherRoom = new Room(10, 10);
            Enemy enemy = new Enemy('e' , "imges/ezgif/tile196.png");

            enemy.x = 3;
            enemy.y = 3;

            startingRoom.North = otherRoom;
            CurrentScene = startingRoom;
            //otherRoom.South = otherRoom;

            //startingRoom.South = otherRoom;
            //startingRoom.West = otherRoom;
            //startingRoom.East = otherRoom;


            startingRoom.AddEntity(new Wall(0, 0, "imges/ezgif/tile012.png"));
            startingRoom.AddEntity(new Wall(1, 4,"imges/ezgif/tile012.png"));
            startingRoom.AddEntity(new Wall(2, 4, "imges/ezgif/tile012.png"));
            startingRoom.AddEntity(new Wall(3, 2, "imges/ezgif/tile012.png"));
            //add a border
            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(i, otherRoom.SizeY, "imges/ezgif/tile012.png"));
                }
            }


            for (int i = 0; i < startingRoom.SizeX; i++)
            {
                otherRoom.AddEntity(new Wall(i, startingRoom.SizeY - 1, "imges/ezgif/tile012.png"));
            }


            for (int i = 0; i < otherRoom.SizeX; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(i, 0, "imges/ezgif/tile012.png"));
                }
            }

            for (int i = 0; i < otherRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(0, i, "imges/ezgif/tile012.png"));
                }
            }

            for (int i = 0; i < otherRoom.SizeY; i++)
            {
                if (i != 2)
                {
                    otherRoom.AddEntity(new Wall(otherRoom.SizeX - 1, i, "imges/ezgif/tile012.png"));
                }
            }



            startingRoom.AddEntity(new Wall(3, 2, "imges/ezgif/tile012.png"));
            startingRoom.AddEntity(new Wall(3, 2, "imges/ezgif/tile012.png"));
            startingRoom.AddEntity(new Wall(3, 2, "imges/ezgif/tile012.png"));

            startingRoom.AddEntity(new Wall(4, 3, "imges/ezgif/tile012.png"));
            startingRoom.AddEntity(new Wall(5, 3, "imges/ezgif/tile012.png"));
            Player player = new Player("imges/ezgif/tile195.png");
            otherRoom.AddEntity(enemy);
            startingRoom.AddEntity(player);
            player.x = 1;
            player.y = 1;
            

        }

        public void Run()
        {
            Init();


       //     PlayerInput.AddKeyEvent(Quit, ConsoleKey.Escape); (no longer needed)



            //Loop until the game is over
            while (!Gameover && !RL.WindowShouldClose())
            {
                //Start the Scene if needed
                if (_currentScene != _nextScene)
                {
                    _currentScene = _nextScene;
                    _currentScene.Start();
                }

                //update the active Scene
                _currentScene.Update();

                int mouseX = (RL.GetMouseX() + 320) / 2;
                int mouseY = (RL.GetMouseY() - 240) / 4;

                Raylib.Vector3 cameraPosition = new Raylib.Vector3(-10, -10, -10);
                Raylib.Vector3 cameraTarget = new Raylib.Vector3(mouseX, 0, mouseY);
                Raylib.Vector3 cameraUp = new Raylib.Vector3(0, 0, 1);




                _camera = new Camera3D(cameraPosition, cameraTarget, cameraUp);


                RL.BeginDrawing();
                RL.BeginMode3D(_camera);
                _currentScene.Draw();
                RL.EndMode3D();
                RL.EndDrawing();


            }
        }
        public static Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
            set
            {
                _nextScene = value;
            }
        }
        public void Quit()
        {
            Gameover = true;
        }

        private Enemy _enemy = new Enemy();


            
    }
}
