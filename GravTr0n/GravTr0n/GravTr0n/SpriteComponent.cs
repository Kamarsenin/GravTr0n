using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GravTr0n
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteComponent : DrawableGameComponent, IDrawSprites
    {
        private SpriteBatch _drawer;
        
        protected List<Player> _toDraw = new List<Player>();

        public SpriteComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _drawer = new SpriteBatch(Game.GraphicsDevice);
        }

        public void AddDrawable(Player drawable)
        {
            if (drawable == null || _toDraw.Contains(drawable))
            {
                Console.WriteLine("Unable to add drawable!");
                return;
            }
            _toDraw.Add(drawable);
        }

        public void RemoveDrawable(Player toRemove)
        {
            _toDraw.Remove(toRemove);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _drawer.Begin();
            foreach (Player drawData in _toDraw)
            {
                drawElement(drawData);
            }
            _drawer.End();
        }

        protected virtual void drawElement(Player drawable)
        {
            _drawer.Draw(drawable.Art,drawable.Destination,
                drawable.Source, Color.White);
        }
    }
}
