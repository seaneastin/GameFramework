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



        public Scene()
        {
            _sizeX = 10;
            _sizeY = 13;
        }

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
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
            foreach (Entity e in _entities)
            {
                e.start();
            }
        }
        public void Update()
        {
            foreach (Entity e in _entities)
            {
                e.Update();
            }
        }


        public void Draw()
        {
            //clear the screen
            Console.Clear();

            char[,] display = new char[_sizeX, _sizeY ];

            foreach (Entity e in _entities)
            {
                //posistion each Entity's icon in the display
                if (e.x >= 0 && e.x < _sizeX && e.y >= 0 && e.y < _sizeY)
                {
                    display[e.x,e.y] = e.Icon;
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

    }
}
