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
        public Matrix transform;
        private Viewport _view;
        private Vector2 _centre;

        
        public Camera(Viewport view)
        {
            _view = view;
        }

        public void Update(GameTime gameTime, Player player)
        {

          //  _centre = new Vector2(player.Destination.X , player.Destination.Y);
            //_centre = new Vector2(player.Position.X + (player.Destination.Width / 2), player.Position.Y + (player.Destination.Height / 2));

            _centre = new Vector2(player.Position.X - 300, player.Position.Y + (_view.Height / 2)- 500);

            transform = Matrix.CreateScale(new Vector3(1, 1, 0))
                * Matrix.CreateTranslation(new Vector3(-_centre.X, -_centre.Y, 0));

           // * Matrix.CreateTranslation(new Vector3(-player.Position.X + (player.Destination.Width / 2), -player.Position.Y + (player.Destination.Height / 2), 0));
        }

        public override string ToString()
        {
            return _centre.ToString();
        }
    }
}