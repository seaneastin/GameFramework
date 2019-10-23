﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GameFramework
{
    delegate void Event();

    class Entity
    {
        public Event Onstart;
        public Event OnUpdate;
        public Event OnDraw;

        private Vector2 _location = new Vector2();


        public char Icon { get; set; } = ' ';
        //the image representing the entity on the screen
        public Texture2D Sprite { get; set; }

        public bool Solid { get; set; } = false;

        public float x
        {
            get
            {
                return _location.X;
            }
            set
            {
                _location.X = value;
            }
        }
        public float y
        {
            get
            {
                return _location.Y;
            }
            set
            {
                _location.Y = value;
            }
        }


        private Scene _scene;
        public Scene MyScene
        {
            set
            {
                _scene = value;

            }
            get
            {
                return _scene;
            }
        }


        public Entity()
        {

        }

        public Entity(char icon)
        {
            Icon = icon;
        }


        //creates an Entity with the specified icon and image
        public Entity(char icon, string imageName) : this (icon)
        {
            Sprite = RL.LoadTexture(imageName);
        }

        

        public void start()
        {
            Onstart?.Invoke();
        }
        public void Update()
        {
            OnUpdate?.Invoke();
        }
        public void Draw()
        {
            OnDraw?.Invoke();
        }

    }
}
