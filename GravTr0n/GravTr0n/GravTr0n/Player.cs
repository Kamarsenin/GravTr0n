using System;
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

        public Player(Texture2D art, int numberOfFrames)
        {
            Art = art;
            Source = art.Bounds;
            Destination = Source;
            BlendColor = Color.White;
            Faceing = Direction.Right;
            NumberOfFrames = numberOfFrames;
            StartingOffset = Point.Zero;
            _currentFrame = 0;
        }


        //Animation

        public int NumberOfFrames { get; set; }
        public int CurrentFrame
        {
            get { return _currentFrame; }
            set
            {
                _currentFrame = value;
                if (CurrentFrame >= NumberOfFrames)
                    CurrentFrame = 0;
                Rectangle newSource = Source;
                newSource.X = StartingOffset.X + _currentFrame * newSource.Width;
                Source = newSource;
            }
        }

        private int _currentFrame;

        public Point StartingOffset { get; set; }


    }
}
