using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeiGratia.src.Camera
{
    internal class Camera2D
    {
        private float _zoom;
        private float _rotation;
        public Matrix Transform;
        private Vector2 _position;

        public Vector2 Position { get => _position; set => _position = value; }
        private float Zoom
        {
            get => _zoom;
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        //Rotation will not be used in this project
        private float Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public Camera2D()
        {
            Zoom = 1.0f;
            _position = Vector2.Zero;
            Rotation = 0.0f;
        }

        public void Move(Vector2 amount)
        {
            _position += amount;
        }


        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            Viewport viewport = graphicsDevice.Viewport;
            Transform =
              Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));
            return Transform;
        }
    }
}
