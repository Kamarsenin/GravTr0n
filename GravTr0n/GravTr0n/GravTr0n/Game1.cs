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
        private AnimationController _animController;
        private AnimationController _menuButton1Controller;
        private AnimationController _menuButton2Controller;
        private AnimatedDrawable _menuButton1;
        private AnimatedDrawable _menuButton2;
        MouseState mouseState;
        MouseState previousMouseState;
        IInputService input;
        GameState gameState;
        enum GameState
        {
            StartMenu,
            Playing
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteComponent renderer = new SpriteComponent(this);
            InputManager input = new InputManager(this);
            Components.Add(renderer);
            Components.Add(input);
            Services.AddService(typeof(IDrawSprites), renderer);
            Services.AddService(typeof(IInputService), input);
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
            IsMouseVisible = true;
            gameState = GameState.StartMenu;
            input = (IInputService)Services.GetService(typeof(IInputService));
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

            Rectangle playerRect = new Rectangle(0, 0, 100, 117);
            _player = new Player(_playerArt, 5, playerRect, input);
            
            IDrawSprites renderer = (IDrawSprites) Services.GetService(typeof(IDrawSprites));    
            
            renderer.AddDrawable(_player);

            _animController = new AnimationController(_player, 0.3f);

            _camera = new Camera(new Viewport((int)_player.Position.X, (int)_player.Position.Y, GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2));

            Texture2D _buttonArt = Content.Load<Texture2D>("meny");

            Rectangle menuButton1Rect = new Rectangle(0, 0, 143, 98);
            _menuButton1 = new AnimatedDrawable(_buttonArt, 5, menuButton1Rect);
            _menuButton1.Position = new Vector2(GraphicsDevice.Viewport.Width / 2 - 70, GraphicsDevice.Viewport.Height / 2 - 143);
            _menuButton1Controller = new AnimationController(_menuButton1, 0.1f);

            Rectangle menuButton2Rect = new Rectangle(0, 0, 143, 98);
            _menuButton2 = new AnimatedDrawable(_buttonArt, 5, menuButton2Rect);
            _menuButton2.Position = new Vector2(GraphicsDevice.Viewport.Width / 2 - 70, (GraphicsDevice.Viewport.Height / 2 - 45));
            _menuButton2Controller = new AnimationController(_menuButton2, 0.1f);
            _menuButton2.StartingOffset = new Point(_menuButton2.StartingOffset.X, 98);

            renderer.AddDrawable(_menuButton1);
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

            if (input.CheckQuit())
                this.Exit();

            _camera.Update(gameTime, -_rotation, _player.Position, 0.7f);
            _animController.Update(gameTime);

            _menuButton1Controller.Update(gameTime);
            _menuButton2Controller.Update(gameTime);

            _player.Update();
            mouseState = Mouse.GetState();
            if (previousMouseState.LeftButton == ButtonState.Pressed &&
                mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
            previousMouseState = mouseState;
            if (gameState == GameState.Playing)
            {
                
            }
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
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            if (gameState == GameState.StartMenu)
            {
                Rectangle menuButton1Rect = new Rectangle((int)_menuButton1.Destination.X, (int)_menuButton1.Destination.Y,
                                                                143, 98);
                Rectangle menuButton2Rect = new Rectangle((int)_menuButton2.Destination.X, (int)_menuButton2.Destination.Y,
                                                                143, 98);
                if (mouseClickRect.Intersects(menuButton1Rect))
                {
                    gameState = GameState.Playing;
                }
                else if (mouseClickRect.Intersects(menuButton2Rect))
                {
                    this.Exit();
                }
            }
        }
    }
}
