using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    public class AnimatedDrawable : DrawData
    {
        private int _currentFrame;
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
    }
}
