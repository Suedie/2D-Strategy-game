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
        private float zoom;
        private float rotation;
        public Matrix transform;
        private Vector2 position;

        public Vector2 Position { get => position; set => position = value; }
        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; if (zoom < 0.1f) zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Camera2D()
        {
            Zoom = 1.0f;
            position = Vector2.Zero;
            Rotation = 0.0f;
        }

        public void move(Vector2 amount)
        {
            position += amount;
        }


        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            Viewport viewport = graphicsDevice.Viewport;
            transform =
              Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));
            return transform;
        }
    }
}
