﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;
using System.Diagnostics;

namespace GameFramework
{
    delegate void Event();

    class Entity
    {
        public Event Onstart;
        public Event OnUpdate;
        public Event OnDraw;

        protected Entity _parent = null;
        protected List<Entity> _children = new List<Entity>();

        //private Vector3 _location = new Vector3(0, 0, 1); //set z to  1 for it to be a point set it to 0 to be a vector

        private Vector2 _velocity = new Vector2();
        //private Matrix3 _transform = new Matrix3();

        //private Matrix3 _translation = new Matrix3();
        //private Matrix3 _rotation = new Matrix3();
        //private Matrix3 _scale = new Matrix3();
        //private float _scale = 1;
        private Matrix3 _localTransform = new Matrix3();
        private Matrix3 _globalTransform = new Matrix3();



        public char Icon { get; set; } = ' ';
        //the image representing the entity on the screen
        public SpriteEntity Sprite { get; set; }

        public bool Solid { get; set; } = false;

        public float OriginX { get; set; } = 0;
        public float OriginY { get; set; } = 0;

        public float x
        {
            get
            {
                return _localTransform.m13;
            }
            set
            {
                _localTransform.SetTranslation(value, y, 1);
                UpdateTransform();
            }
        }
        public float y
        {
            get
            {
                return _localTransform.m23;
            }
            set
            {
                _localTransform.SetTranslation(x, value, 1);
                UpdateTransform();
            }
        }

        public float XAbsolute
        {
            get
            {
               return _globalTransform.m13;  
            }
        }

        public float YAbsolute
        {
            get
            {
                return _globalTransform.m23;
            }
        }

        //the entity's velocity on the X axis
        public float xVelocity
        {
            get
            {
                return _velocity.X;
                //return _translation.m13;
            }
            set
            {
                _velocity.X = value;
                //_translation.SetTranslation(value, yVelocity, 1);
            }
        }

        public float yVelocity
        {
            get
            {
                return _velocity.Y;
                //return _translation.m23;
            }
            set
            {
                _velocity.Y = value;
                //_translation.SetTranslation(xVelocity, value, 1);
            }
        }

        public float Size
        {
            get
            {
                //return _scale;
                return 1;
            }
            //   set
            //  {
            //     _localTransform.SetScaled(value, value, 1);
            //_scale = value;
            //  }
        }
        public float Rotation
        {
            get
            {
                return (float)Math.Atan2(_localTransform.m21, _localTransform.m11);
            }
            // set
            // {
            //_rotation.SetRotateZ(value); original code by sean
            //     _localTransform.SetRotateZ(value);
            // }
        }

        public void UpdateTransform()
        {
            if (_parent != null)
            {
                _globalTransform = _parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }

            foreach (Entity child in _children)
            {
                child.UpdateTransform();
            }
        }

        public Entity Parent
        {
            get
            {
                return _parent;
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
            Sprite = new SpriteEntity();
            Sprite.Load(imageName);
            Icon = icon;
            OnUpdate += rotateall;
            AddChild(Sprite);
        }
        public void rotateall()
        {
             //Rotate(9000f);
        }

        public int GetChildCount()
        {
            return _children.Count;
        }

        public Entity GetChild(int index)
        {
            return _children[index];
        }

        public void AddChild(Entity child)
        {
            //Make sure the child doesn't already have a parent
            Debug.Assert(child._parent == null);
            //Assign this Entity as the child's parent
            child._parent = this;
            //Add child to collection
            _children.Add(child);
        }

        public void RemoveChild(Entity child)
        {
            bool isMyChild = _children.Remove(child);
            if (isMyChild)
            {
                child._parent = null;
            }
        }


        ~Entity()
        {
            if (_parent != null)
            {
                _parent.RemoveChild(this);
            }
            foreach (Entity e in _children)
            {
                e._parent = null;
            }
        }


        //scale the entiy by the specified amount
        public void Scale(float with, float height)
        {
            _localTransform.Scale(with, height, 1);
            UpdateTransform();
        }
        //rotate the entity by the specified amount
        public void Rotate(float radians)
        {
            _localTransform.RotateZ(radians);
            UpdateTransform();

        }


        public void start()
        {
            Onstart?.Invoke();
        }
        public void Update()
        {
            // _location += _velocity;
            //  Matrix3 transform = _translation;
            // _location = transform * _location;
            x += _velocity.X;
            y += _velocity.Y;
            OnUpdate?.Invoke();
        }
        public void Draw()
        {
            OnDraw?.Invoke();
        }

    }
}
