using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    class CollisionManager : GameComponent, ICollisionService
    {
        //private List<IIsCollidable> _collidables; 

        public CollisionManager(Game game)
            : base(game)
        {
            //_collidables = new List<IIsCollidable>();
        }

        public override void Initialize()
        {
            //_collidables = new List<IIsCollidable>();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            

        }

        public bool IsCollision(Player player, DrawData item)
        {
            if (player.Destination.Intersects(item.Destination))
                return true;
            return false;
        }

        public void ResolveCollision(Player player, DrawData item)
        {
            Rectangle overlap = Rectangle.Intersect(player.Destination, item.Destination);
            player.Position -= new Vector2(overlap.X, overlap.Y);
            player.Velocity = new Vector2(0, 0);
            player.VelocityGravity = new Vector2(0, 0);
        }
    }
}
