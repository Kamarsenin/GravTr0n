using System;
using System.Threading;
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
    public class ScreenMenu : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        private PlayerAnimationController _startButtonController;
        private PlayerAnimationController _exitButtonController;
        private Texture2D menuSpriteSheet;
        private Thread backgroundThread;
        private bool isLoading = false;
        MouseState mouseState;
        MouseState previousMouseState;
        GameState gameState;
        private Player _startButton;
        private Player _exitButton;
        Game1 test;
        public enum GameState
        {
            StartMenu,
            Loading,
            Playing
        } 

        public ScreenMenu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteComponent renderer = new SpriteComponent(this);
            Components.Add(renderer);
            Services.AddService(typeof(IDrawSprites), renderer);
            gameState = GameState.StartMenu;
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
            mouseState = Mouse.GetState();
            previousMouseState = mouseState;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            menuSpriteSheet = Content.Load<Texture2D>("meny");
            _startButton = new Player(menuSpriteSheet, 5);
            _startButton.Source = new Rectangle(0, 0, 143, 98);
            _startButton.Destination = new Rectangle(GraphicsDevice.Viewport.Width / 2 - 98, GraphicsDevice.Viewport.Height / 2 - 143, 143, 98);

            _exitButton = new Player(menuSpriteSheet, 5);
            _exitButton.Source = new Rectangle(0, _startButton.Source.Height, 143, 98);
            _exitButton.Destination = new Rectangle(GraphicsDevice.Viewport.Width / 2 - 98, (GraphicsDevice.Viewport.Height / 2 - 45), 143, 98);

            IDrawSprites renderer = (IDrawSprites)
                Services.GetService(typeof(IDrawSprites));
            renderer.AddDrawable(_startButton);
            renderer.AddDrawable(_exitButton);

            _exitButtonController = new PlayerAnimationController(_exitButton, 0.1f);
            _startButtonController = new PlayerAnimationController(_startButton, 0.1f);
        }
        void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            if (gameState == GameState.StartMenu)
            {
                Rectangle startButtonRectangle = new Rectangle((int)_startButton.Destination.X, (int)_startButton.Destination.Y,
                                                                143, 98);
                Rectangle exitButtonRectangle = new Rectangle((int)_exitButton.Destination.X, (int)_exitButton.Destination.Y,
                                                                143, 98);
                if (mouseClickRect.Intersects(startButtonRectangle))
                {
                    gameState = GameState.Playing;
                    isLoading = true;
                }
                else if (mouseClickRect.Intersects(exitButtonRectangle))
                {
                    this.Exit();
                }
            }

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _startButtonController.Update(gameTime);
            _exitButtonController.Update(gameTime);

            mouseState = Mouse.GetState();
            if (previousMouseState.LeftButton == ButtonState.Pressed &&
                mouseState.LeftButton == ButtonState.Released)
            {
                MouseClicked(mouseState.X, mouseState.Y);
            }
            previousMouseState = mouseState;
            if (gameState == GameState.Playing && isLoading)
            {
                test = new Game1();
                isLoading = false;
            }
            base.Update(gameTime);
        }
    }
}
