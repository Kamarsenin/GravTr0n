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
        private Vector2 _resistance;
        private Vector2 _gravityDown;
        private Vector2 _gravityDirection;
        private float _acceleration;
        //private IInputService _input;
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
        
        public Player(Texture2D art, int numberOfFrames, Rectangle source) 
            : base(art, numberOfFrames, source, 0.1f)
        {
            Facing = Events.Idle;
            _resistance = new Vector2(1, 0);
            _acceleration = 0.2f;
            //_input = input;
        }

        public void Update(GameTime gameTime, IInputService input)
        {
            if (input.CheckMoveRight() && Velocity.X < 20)
            {
                Velocity *= _acceleration;
                Facing = Events.MoveRight;
            }
            else if (input.CheckMoveLeft() && Velocity.X > -20)
            {
                Velocity *= _acceleration;
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
                    Velocity -= _resistance;
                else if (Velocity.X < 0)
                    Velocity += _resistance;
            }

            Position += Velocity;

            base.Update(gameTime);
        }
    }
}
