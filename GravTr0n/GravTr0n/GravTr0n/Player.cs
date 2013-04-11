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

    public class Player : AnimatedDrawable
    {   
        // MORTEN SITT
        public Vector2 Velocity { get; set; }
        // MORTEN SITT SLUTT

        // Which way am I facing?
        public Direction Facing { 
            get
            {
                return _facing;
            }
            set
            {
                //Kun hvis endret
                if (_facing != value)
                {
                    _facing = value;
                    int temp = 2;
                    if (_facing == Direction.Idle)
                    {
                        temp = 2;
                    }
                    else if (_facing == Direction.Right)
                    {
                        temp = 0;
                    }
                    else if (_facing == Direction.Left)
                    {
                        temp = 1;
                    }
                    else if (_facing == Direction.InAir)
                    {
                        temp = 3;
                    }

                    StartingOffset = new Point(StartingOffset.X, Destination.Height * temp);

                    //Nullstill frames
                    CurrentFrame = 0;
                }
            }
        }
        private Direction _facing;

        public Player(Texture2D art, int numberOfFrames, Rectangle source) : base(art, numberOfFrames, source)
        {
            Facing = Direction.Idle;
        }

        public void Update()
        {
            Position += Velocity;
        }
    }
}
