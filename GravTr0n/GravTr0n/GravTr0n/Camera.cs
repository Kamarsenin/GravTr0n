using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    class Camera
    {
        public Vector2 Position { get; set; }
        private Viewport _viewPort;

        public Camera(Viewport viewPort)
        {
            this._viewPort = viewPort;
            Position = Vector2.Zero;
        }
        public Matrix GetViewPortMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0f));
        }
    }
}
