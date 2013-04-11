using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public Viewport Viewport { get; private set; }

        public Camera(Viewport viewport)
        {
            Transform = Matrix.Identity;
            Viewport = viewport;
        }

        public void Update(GameTime gameTime, float rotation, Vector2 position, float zoom)
        {
            Transform = Matrix.CreateTranslation(position.X, position.Y, 0) *
                        Matrix.CreateTranslation(Viewport.Width, Viewport.Height, 0)
                /*
                        Matrix.CreateRotationZ(rotation) *
                        Matrix.CreateScale(zoom) *
                       */;
        }
    }
}
