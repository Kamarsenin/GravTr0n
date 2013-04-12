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
    public enum GameState
    {
        StartMenu,
        Playing,
        KeyBindings,
        Quit
    }
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

        private GameState _gameState;
        private int _gameStateCheck;

        private bool _isPaused;
        private bool _isPauseKeyDown;
        private bool _restart;
        private bool _isRestartKeyDown;
        IInputService input;
        IDrawSprites renderer;
        ICollisionService collisionManager;

        private StartMenu _startMenu;
        private int _screenWidth;
        private int _screenHeight;

        private KeyBindingsMenu _keyMenu;
        private Level01 _level01;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            SpriteComponent renderer = new SpriteComponent(this);
            InputManager input = new InputManager(this);
            CollisionManager collisionManager = new CollisionManager(this);
            Components.Add(renderer);
            Components.Add(input);
            Components.Add(collisionManager);
            Services.AddService(typeof(IDrawSprites), renderer);
            Services.AddService(typeof(IInputService), input);
            Services.AddService(typeof(ICollisionService), collisionManager);
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
            _gameState = GameState.StartMenu;
            _gameStateCheck = 0;
            input = (IInputService)Services.GetService(typeof(IInputService));
            renderer = (IDrawSprites)Services.GetService(typeof(IDrawSprites));
            collisionManager = (ICollisionService)Services.GetService(typeof(ICollisionService));
            _screenWidth = GraphicsDevice.Viewport.Width;
            _screenHeight = GraphicsDevice.Viewport.Height;

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

            Texture2D _buttonArt = Content.Load<Texture2D>("meny");
            Texture2D _keysBindingArt = Content.Load<Texture2D>("keysSprite2");
            _keyMenu = new KeyBindingsMenu(_keysBindingArt, _screenWidth, _screenHeight, _gameState, _gameStateCheck);
            _startMenu = new StartMenu(_buttonArt, _screenWidth, _screenHeight, _gameState, _gameStateCheck);  

            Texture2D _playerArt = Content.Load<Texture2D>("spritesheettest1");
            Rectangle playerRect = new Rectangle(0, 0, 100, 117);
            _player = new Player(_playerArt, 5, playerRect);

            Texture2D terrainArt = Content.Load<Texture2D>("spriteTerrain");
            _level01 = new Level01(terrainArt, _playerArt, _gameState, _gameStateCheck, _player);
            
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

            if (input.CheckQuit())
                this.Exit();

            CheckPauseKey();

            if (!_isPaused)
            {
                CheckRestartKey();

                if (_restart)
                {
                    _restart = false;
                    _gameState = GameState.StartMenu;
                    _startMenu.GameState = _gameState;
                    _gameStateCheck = 0;
                    _startMenu.GameStateCheck = _gameStateCheck;
                }
                else if (_gameState == GameState.StartMenu)
                {
                    if (_gameStateCheck == 0)
                    {
                        _gameStateCheck = -1;
                        renderer.ClearDrawable();
                        _startMenu.AddDraw(renderer);
                    }
                    
                    _startMenu.Update(gameTime, input);

                    if (!_gameState.Equals(_startMenu.GameState))
                    {
                        _gameState = _startMenu.GameState;
                        _keyMenu.GameState = _gameState;
                        _gameStateCheck = _startMenu.GameStateCheck;
                        _keyMenu.GameStateCheck = _gameStateCheck; 
                    }
                }
                else if (_gameState == GameState.Playing)
                {
                    if (_gameStateCheck == 2)
                    {
                        _gameStateCheck = -1;
                        _startMenu.RemoveDraw(renderer);
                        _level01.AddDraw(renderer);
                    }

                    _level01.Update(collisionManager);
                    _player.Update(gameTime, input);
                    
                }
                else if (_gameState == GameState.KeyBindings)
                {
                    if (_gameStateCheck == 1)
                    {
                        _gameStateCheck = -1;
                        _startMenu.RemoveDraw(renderer);
                        _keyMenu.AddDraw(renderer);
                    }
                    _keyMenu.Update(gameTime, input);

                    if (!_gameState.Equals(_keyMenu.GameState))
                    {
                        _gameState = _keyMenu.GameState;
                        _startMenu.GameState = _gameState;
                        _gameStateCheck = _keyMenu.GameStateCheck;
                        _startMenu.GameStateCheck = _gameStateCheck;
                    }
                }
                else if (_gameState == GameState.Quit)
                {
                    this.Exit();
                }

                _camera.Update(gameTime, -_rotation, _player.Position, 0.7f);
                
                base.Update(gameTime);
            }
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
        
        void CheckPauseKey()
        {
            if (input.CheckPause())
            {
                _isPauseKeyDown = true;
            }
            else if (_isPauseKeyDown)
            {
                _isPauseKeyDown = false;
                _isPaused = !_isPaused;
            }
        }

        void CheckRestartKey()
        {
            if (input.CheckRestart())
            {
                _isRestartKeyDown = true;
            }
            else if (_isRestartKeyDown)
            {
                _isRestartKeyDown = false;
                _restart = true;
            }
        }
    }
}
