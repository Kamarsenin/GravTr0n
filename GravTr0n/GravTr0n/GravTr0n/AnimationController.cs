using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    class AnimationController
    {
        public AnimatedDrawable _player;
        // time between frames => Change to increase/decrease
        public float StepTime { get; set; }
        private float _timer;

        public AnimationController(AnimatedDrawable player,
            float animationStepTime)
        {
            _player = player;
            StepTime = animationStepTime;
        }

        public virtual void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= StepTime)
            {
                _timer -= StepTime;
                _player.CurrentFrame++;
            }
        }
    }
}