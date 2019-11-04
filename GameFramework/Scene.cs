using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    class Scene
    {


        private List<Entity> _entities = new List<Entity>();
        private List<Entity> _removals = new List<Entity>();
        //the list of entities to add to the scene
        private List<Entity> _additions = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        private bool[,] _collision;
        private List<Entity>[,] _tracking;


        public Event Onstart;
        public Event OnUpdate;
        public Event OnDraw;

        public Scene() : this(6, 6)
        {

        }

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _collision = new bool[_sizeX, _sizeY];
            //create the tracking grid
            _tracking = new List<Entity>[_sizeX, _sizeY];
        }


        public int SizeX
        {
            get
            {
                return _sizeX;
            }
        }
        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }

        public void Start()
        {
            Onstart?.Invoke();

            foreach (Entity e in _entities)
            {
                e.start();
            }
        }
        public void Update()
        {
            //clear the collision grid

            OnUpdate?.Invoke();
            //Create the collision gri

            //clear the tracking grid
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    _tracking[x, y] = new List<Entity>();
                }
                Console.WriteLine();
            }

            foreach (Entity e in _additions)
            {
                _entities.Add(e);
            }
            _additions.Clear();


            foreach (Entity e in _removals)
            {
                //Remove e from _entities
                _entities.Remove(e);
            }
            _removals.Clear();


            foreach (Entity e in _entities)
            {
                //position each entity's icon in the collision grid
                int x = (int)e.x;
                int y = (int)e.y;
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    _tracking[x, y].Add(e);

                    if (!_collision[x,y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }
            }
            foreach (Entity e in _entities)
            {
                //Call the Entity's Update events
                e.Update();
            }
        }


        public void Draw()
        {

            OnDraw?.Invoke();

            //clear the screen





            Console.Clear();
            RL.ClearBackground(Color.DARKBROWN);


            char[,] display = new char[_sizeX, _sizeY ];

            foreach (Entity e in _entities)
            {
                int x = (int)e.x;
                int y = (int)e.y;
                //posistion each Entity's icon in the display
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    display[x,y] = e.Icon;
                }
                //e.Draw();
            }
            for (int i = 0; i < _sizeY; i++) 
            {
                for (int j = 0; j < _sizeX; j++)
                {
                    Console.Write(display[j, i]);
                    foreach (Entity e in _tracking[j, i])
                    {
                        RL.DrawTexture(e.Sprite, (int)e.x * 16, (int)e.y * 16, Color.WHITE);
                        Texture2D texture = e.Sprite;
                        Raylib.Vector2 position = new Raylib.Vector2(e.x * Game.SizeX, e.y * Game.SizeY);
                        float rotation = 0.0f;
                        float scale = e.Scale;
                        RL.DrawTextureEx(texture , position , rotation , scale , Color.WHITE);
                    }
                }
                Console.WriteLine();
            }
            foreach (Entity e in _entities)
            {
                e.Draw();
            }
        }

        //adds an Entity to the Scene
        public void AddEntity(Entity entity)
        {
            _additions.Add(entity);
            entity.MyScene = this;
        }

        //removes an entity form the scene
        public void RemoveEntity(Entity entity)
        {
            _removals.Add(entity);
            entity.MyScene = null;
        }




        public void ClearEntity()
        {
            foreach (Entity e in _entities)
            {
                RemoveEntity(e);
            }
 
        }
        //returns whether there is a solid entity at the point
        public bool GetCollision(float x, float y)
        {
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {


                return _collision[(int)x, (int)y];
            }
            else
            {
                return false;
            }
        }

        //Returns the List of ENtities at a specific point
        public List<Entity> GetEntities(float x, float y)
        {
            //Ensure the point is within the Scene
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _tracking[(int)x, (int)y];
            }

            else
            {
                return new List<Entity>();
            }
            return new List<Entity>();
        }
    }
}
