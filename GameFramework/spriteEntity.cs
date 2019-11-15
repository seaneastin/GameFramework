using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;
namespace GameFramework
{
    class SpriteEntity : Entity
    {
        private Texture2D _texture = new Texture2D();
        private Image _image = new Image();



        public float Width
        {
            get { return _texture.width / Game.UnitSize.X; }
        }

        public float Height
        {
            get { return _texture.height / Game.UnitSize.Y; }
        }


        public float Top
        {
            get { return YAbsolute + 0.5f; }
        }

        public float Bottom
        {
            get { return YAbsolute + Height + 0.5f;  }
        }

        public float Left
        {
            get { return XAbsolute + 0.5f; }
        }

        public float right
        {
            get { return XAbsolute + Width + 0.5f; }
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public SpriteEntity()
        {

        }

        public void Load(string path)
        {
            _image = RL.LoadImage(path);
            _texture = RL.LoadTextureFromImage(_image);
            x = -Width / 2;
            y = -Height / 2;
        }
    }
}
