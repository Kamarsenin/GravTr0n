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
        private float _stepTime;
        private float _timer;

        public PlayerAnimationController(Player Player,
            float animationStepTime)
        {
            _player = Player;
            _stepTime = animationStepTime;
        }

        public virtual void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timer >= _stepTime)
            {
                _timer -= _stepTime;
                _player.CurrentFrame++;
            }
        }
    }
}
