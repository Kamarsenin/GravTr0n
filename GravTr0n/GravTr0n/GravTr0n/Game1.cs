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
        private AnimatedDrawable _menuButton1;
        private AnimatedDrawable _menuButton2;

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

            IDrawSprites renderer = (IDrawSprites) Services.GetService(typeof(IDrawSprites));
            renderer.AddDrawable(_player);

            _animController = new AnimationController(_player, 0.3f);

            _camera = new Camera(new Viewport((int)_player.Position.X, (int)_player.Position.Y, GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2));

            Texture2D _buttonArt = Content.Load<Texture2D>("meny");

            _menuButton1 = new AnimatedDrawable();
            _menuButton1.Art = _buttonArt;
            _menuButton1.NumberOfFrames = 5;
            _menuButton1.Source = new Rectangle(0, 0, 143, 98);
            _menuButton1.Position = new Vector2(GraphicsDevice.Viewport.Width / 2 - 98, GraphicsDevice.Viewport.Height / 2 - 143);
            renderer.AddDrawable(_menuButton1);

            _menuButton2 = new AnimatedDrawable();
            _menuButton2.Art = _buttonArt;
            _menuButton2.NumberOfFrames = 5;
            _menuButton2.Source = new Rectangle(0, _menuButton1.Source.Height, 143, 98);
            _menuButton2.Position = new Vector2(GraphicsDevice.Viewport.Width / 2 - 98, (GraphicsDevice.Viewport.Height / 2 - 45));
            renderer.AddDrawable(_menuButton2);
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

            if (buttonpenis.IsKeyDown(Keys.D) && _player.Velocity.X < 20)
            {
                _player.Velocity += new Vector2(1, 0);
                _player.Facing = Direction.Right;
            }
            else if (buttonpenis.IsKeyDown(Keys.A) && _player.Velocity.X > -20)
            {
                _player.Velocity += new Vector2(-1, 0);
                _player.Facing = Direction.Left;
            }
            else if (_player.Velocity.Equals(Vector2.Zero))
            {
                _player.Facing = Direction.Idle;
            }
            else
            { 
                if (_player.Velocity.X > 0)
                    _player.Velocity -= new Vector2(1f, 0f);
                else if (_player.Velocity.X < 0)
                    _player.Velocity += new Vector2(1f, 0f);  
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
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone, null, _camera.Transform);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
