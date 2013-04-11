using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    public class PlayerAnimationController
    {
        public Player _player;
        public float StepTime { get; set; }
        private float _timer;

        public PlayerAnimationController(Player Player,
            float animationStepTime)
        {
            _player = Player;
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
