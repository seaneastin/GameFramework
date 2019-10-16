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
            player player = new player();
            Entity enemy = new Entity('#');
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
