﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    public enum Direction
    {
        Left,
        Right,
        InAir,
        Idle
    }

    public class Player
    {
        public Texture2D Art { get; set; }

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
        public Rectangle Source { get; set; }
        public Color BlendColor { get; set; }
        public Direction Faceing { get; set; }

        private Rectangle _destination;
        private Vector2 _position;

        public Player(Texture2D art)
            : this(art, art.Bounds)
        {}

        public Player(Texture2D art, Rectangle destination)
        {
            Art = art;
            Source = art.Bounds;
            Destination = destination;
            BlendColor = Color.White;
            Faceing = Direction.Right;
        }
    }
}
