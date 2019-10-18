using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
