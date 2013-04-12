using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    class CollisionManager : GameComponent, ICollisionService
    {
        public CollisionManager(Game game)
            : base(game)
        {

        }
    }
}
