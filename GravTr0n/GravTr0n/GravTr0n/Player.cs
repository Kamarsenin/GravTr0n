using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    
    public class Player : AnimatedDrawable
    {   
        // MORTEN SITT
        public Vector2 Velocity { get; set; }
        private IInputService _input;
        // MORTEN SITT SLUTT

        // Which way am I facing?
        private Events _facing;
        public Events Facing { 
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
                    if (_facing == Events.Idle)
                    {
                        temp = 2;
                    }
                    else if (_facing == Events.MoveRight)
                    {
                        temp = 0;
                    }
                    else if (_facing == Events.MoveLeft)
                    {
                        temp = 1;
                    }
                    else if (_facing == Events.Jump)
                    {
                        temp = 3;
                    }

                    StartingOffset = new Point(StartingOffset.X, Destination.Height * temp);

                    //Nullstill frames
                    CurrentFrame = 0;
                }
            }
        }
        
        public Player(Texture2D art, int numberOfFrames, Rectangle source, IInputService input) 
            : base(art, numberOfFrames, source)
        {
            Facing = Events.Idle;
            _input = input;
        }

        public void Update()
        {
            if (_input.CheckMoveRight() && Velocity.X < 20)
            {
                Velocity += new Vector2(1, 0);
                Facing = Events.MoveRight;
            }
            else if (_input.CheckMoveLeft() && Velocity.X > -20)
            {
                Velocity += new Vector2(-1, 0);
                Facing = Events.MoveLeft;
            }
            else if (Velocity.Equals(Vector2.Zero))
            {
                Facing = Events.Idle;
            }
            else
            {
                if (Velocity.X > 0)
                    // Resistance
                    Velocity -= new Vector2(1f, 0f);
                else if (Velocity.X < 0)
                    Velocity += new Vector2(1f, 0f);
            }

            Position += Velocity;
            
        }
    }
}
