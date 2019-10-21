﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Scene
    {


        private List<Entity> _entities = new List<Entity>();
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


            foreach (Entity e in _entities)
            {
                e.Update();
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
        }


        public void Draw()
        {

            OnDraw?.Invoke();

            //clear the screen
            Console.Clear();

            char[,] display = new char[_sizeX, _sizeY ];

            foreach (Entity e in _entities)
            {
                //posistion each Entity's icon in the display
                if (e.x >= 0 && e.x < _sizeX && e.y >= 0 && e.y < _sizeY)
                {
                    display[(int)e.x,(int)e.y] = e.Icon;
                }
                e.Draw();
            }
            for (int i = 0; i < _sizeY; i++) 
            {
                for (int j = 0; j < _sizeX; j++)
                {
                    Console.Write(display[j, i]);
                }
                Console.WriteLine();
            }
        }

        //adds an Entity to the Scene
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = this;
        }

        //removes an entity form the scene
        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
            entity.MyScene = null;
        }




        public void ClearEntity()
        {
            foreach (Entity e in _entities)
            {
                e.MyScene = null;
            }
            _entities.Clear();
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
