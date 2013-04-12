using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    public class AnimatedDrawable : DrawData
    {
        private int _currentFrame;

        private float _timer;
        public float StepTime { get; set; }
        
        public Point StartingOffset { get; set; }
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
                newSource.X = StartingOffset.X + (_currentFrame * newSource.Width);
                newSource.Y = StartingOffset.Y;
                Source = newSource;
            }
        }

        public AnimatedDrawable(Texture2D art, int numberOfFrames, Rectangle source, float animationStepTime) : base(art, source)
        {
            StartingOffset = Point.Zero;
            NumberOfFrames = numberOfFrames;
            CurrentFrame = 0;
            StepTime = animationStepTime;
        }

        public virtual void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= StepTime)
            {
                _timer -= StepTime;
                CurrentFrame++;
            }
        }
    }
}
