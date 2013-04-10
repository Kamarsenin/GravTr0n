using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    public class Player
    {
        public Vector2 Position
        {
            get { return Position; }
            set { Position = value; }
        }

        public Rectangle CollitionRectangle
        {
            get { return CollitionRectangle; }
            set { CollitionRectangle = value; }
        }
    }
}
