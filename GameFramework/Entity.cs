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




        public char Icon { get; set; } = ' ';

        public int x { get; set; } = 0;
        public int y { get; set; } = 0;

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
