using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    class CollisionManager : GameComponent, ICollisionService
    {
        private List<IIsCollidable> _collidables; 

        public CollisionManager(Game game)
            : base(game)
        {
            _collidables = new List<IIsCollidable>();
        }

        public override void Initialize()
        {
            _collidables = new List<IIsCollidable>();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IIsCollidable item in _collidables)
            {
                                
            }

        }

        public void AddCollidables(IIsCollidable collidableObject)
        {
            _collidables.Add(collidableObject);
        }

        public bool IsCollision()
        {
            return true;
        }

        public void ResolveCollision()
        {

        }
    }
}
