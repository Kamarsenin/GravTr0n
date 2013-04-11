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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Player _player;
        private Camera _camera;
        private float _rotation;
        private PlayerAnimationController _animController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteComponent renderer = new SpriteComponent(this);
            Components.Add(renderer);
            Services.AddService(typeof(IDrawSprites), renderer);
            _rotation = 0.4f;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D _playerArt = Content.Load<Texture2D>("spritesheettest1");
            _player = new Player(_playerArt, 5);

            IDrawSprites renderer = (IDrawSprites)
            Services.GetService(typeof(IDrawSprites));
            renderer.AddDrawable(_player);

            _animController = new PlayerAnimationController(_player, 0.3f);

            _camera = new Camera(new Viewport((int)_player.Position.X, (int)_player.Position.Y, GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            KeyboardState buttonpenis = Keyboard.GetState();

            if (buttonpenis.IsKeyDown(Keys.Escape))
                this.Exit();

            if (buttonpenis.IsKeyDown(Keys.D))
            {
                _player.Velocity = new Vector2(4, 0);
            }
            else if (buttonpenis.IsKeyDown(Keys.A))
            {
                _player.Velocity = new Vector2(-4, 0);
            }
            else
            {
                _player.Velocity = new Vector2(0, 0);
            }


            _camera.Update(gameTime, -_rotation, _player.Position, 0.7f);
            _animController.Update(gameTime);

            _player.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, _camera.Transform);
            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
