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


        private Scene _currentScene;
        public Game()
        {
            _currentScene = new Scene();
        }
        public void Run()
        {
            _currentScene.AddEntity(new Wall(0, 0));
            _currentScene.AddEntity(new Wall(1, 4));
            _currentScene.AddEntity(new Wall(2, 4));
            _currentScene.AddEntity(new Wall(3, 2));
            _currentScene.AddEntity(new Wall(4, 3));
            _currentScene.AddEntity(new Wall(5, 3));
            player player = new player();
            Entity enemy = new Entity('e');
            _currentScene.AddEntity(enemy);
            
            _currentScene.AddEntity(player);

            player.x = 1;
            player.y = 1;
            enemy.x = 1;

            _currentScene.Start();

            //Loop until the game is over
            while (!Gameover)
            {
                _currentScene.Update();
                _currentScene.Draw();
                PlayerInput.ReadKey();
            }
        }
        public Scene CurrentScene
        {
            get
            {
                return _currentScene;
            }
        }
    }
}
