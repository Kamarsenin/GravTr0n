using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    public class DrawData
    {
        private Rectangle _destination;
        private Vector2 _position;

        public Texture2D Art { get; set; }
        public Rectangle Source { get; set; }
        public Color BlendColor { get; set; }

        /// <summary>
        /// Hvor dette objektet tegnes
        /// </summary>
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                _destination.X = (int)_position.X;
                _destination.Y = (int)_position.Y;
            }
        }

        public Rectangle Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                _position.X = _destination.X;
                _position.Y = _destination.Y;
            }
        }

        public DrawData(Texture2D art, Rectangle source)
        {
            Art = art;
            Source = source;
            Destination = Source;
            BlendColor = Color.White;
        }
    }
}
