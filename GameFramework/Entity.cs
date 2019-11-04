using System;
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

        private Vector3 _location = new Vector3(0, 0, 1); //set z to  1 for it to be a point set it to 0 to be a vector

        //private Vector2 _velocity = new Vector2();
        private Matrix3 _transform = new Matrix3();
        
        private Matrix3 _translation = new Matrix3();
        private Matrix3 _rotation = new Matrix3();
        //private Matrix3 _scale = new Matrix3();
        private float _scale = 1;


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

        //the entity's velocity on the X axis
        public float xVelocity
        {
            get
            {
                //return _velocity.X;
                return _translation.m13;
            }
            set
            {
                //_velocity.X = value;
                _translation.SetTranslation(value, yVelocity, 1);
            }
        }

        public float yVelocity
        {
            get
            {
                //return _velocity.Y;
                return _translation.m23;
            }
            set
            {
                //_velocity.Y = value;
                _translation.SetTranslation(xVelocity, value, 1);
            }
        }

        public float Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
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
        public Entity(char icon, string imageName) : this(icon)
        {
            Sprite = RL.LoadTexture(imageName);
            Icon = icon;
        }

        

        public void start()
        {
            Onstart?.Invoke();
        }
        public void Update()
        {
            // _location += _velocity;
            Matrix3 transform = _translation * _rotation;
            _location = transform * _location;
            OnUpdate?.Invoke();
        }
        public void Draw()
        {
            OnDraw?.Invoke();
        }

    }
}
