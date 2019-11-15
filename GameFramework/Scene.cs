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
        private bool _started = false;


        public Event Onstart;
        public UpdateEvent OnUpdate;
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


        public bool Started
        {
            get
            {
                return _started;
            }
        }

        public void Start()
        {
            Onstart?.Invoke();

            foreach (Entity e in _entities)
            {
                e.start();
            }
            _started = true;
        }
        public void Update(float deltatime)
        {
            //clear the collision grid

            OnUpdate?.Invoke(deltatime);
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
                int x = (int)Math.Round(e.XAbsolute);
                int y = (int)Math.Round(e.YAbsolute);
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    _tracking[x, y].Add(e);

                    if (!_collision[x, y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }
            }



            foreach (Entity e in _entities)
            {
                //Call the Entity's Update events
                e.Update(deltatime);
            }
        }


        public void Draw()
        {

            OnDraw?.Invoke();

            //clear the screen





            Console.Clear();
            RL.ClearBackground(Color.DARKBROWN);


            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                int x = (int)Math.Round(e.XAbsolute);
                int y = (int)Math.Round(e.YAbsolute);
                //posistion each Entity's icon in the display
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    display[x, y] = e.Icon;
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
                        if (e.Sprite == null)
                        {
                            continue;
                        }
                        //RL.DrawTexture(e.Sprite, (int)e.x * 16, (int)e.y * 16, Color.WHITE);
                        Texture2D texture = e.Sprite.Texture;
                        //position
                        float positionx = e.Sprite.XAbsolute * Game.UnitSize.X + Game.UnitSize.X / 2;
                        float positiony = e.Sprite.YAbsolute * Game.UnitSize.Y + Game.UnitSize.Y / 2;
                        Raylib.Vector2 position = new Raylib.Vector2(positionx , positiony );
                        //scale
                        float scale = e.Sprite.Size;
                        //rotation
                        float rotation = e.Rotation * (float)(180.0f/Math.PI);
                        //Draw
                        RL.DrawTextureEx(texture, position, rotation, scale, Color.WHITE);
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
            if (_additions.Contains(entity))
            {
                return;
            }
            _additions.Add(entity);
            entity.MyScene = this;
        }

        //removes an entity form the scene
        public void RemoveEntity(Entity entity)
        {
            if (_removals.Contains(entity))
            {
                return;
            }
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
            //this tells whether or not outside of the level has collision
            else
            {
                return true;
            }
        }

        //Returns the List of ENtities at a specific point
        public List<Entity> GetEntities(float x, float y)
        {
            int checkX = (int)Math.Round(x);
            int checkY = (int)Math.Round(y);
            //Ensure the point is within the Scene
            if (checkX >= 0 && checkY >= 0 && x < _sizeX && checkY < _sizeY)
            {
                return _tracking[checkX, checkY];
            }

            else
            {
                return new List<Entity>();
            }
            return new List<Entity>();
        }
    }
}
