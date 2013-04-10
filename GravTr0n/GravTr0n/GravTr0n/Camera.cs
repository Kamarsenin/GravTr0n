using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GravTr0n
{
    class Camera
    {
        public Vector2 Position { get; set; }
        private Viewport _viewPort;

        public Camera(Viewport viewPort)
        {
            this.viewPort = _viewPort;
            Position = Vector2.Zero;
        }
        public Matrix GetViewPortMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position, 0f));
        }
    }
}
