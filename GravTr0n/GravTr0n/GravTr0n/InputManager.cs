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
    public class InputManager : GameComponent, IInputService
    {
        private MouseState _mouseStateCurrent;
        private MouseState _mouseStatePrevious;
        private Point _mousePosition;

        public InputManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            KeyBindings.GenerateKeyBindingsFromXmlFile("Content/keybindings.xml");
            
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            KeyBindings.GetActivatedEvents();
            _mouseStatePrevious = _mouseStateCurrent;
            _mouseStateCurrent = Mouse.GetState();
            _mousePosition = new Point(_mouseStateCurrent.X, _mouseStateCurrent.Y);
            
        }

        public bool CheckMoveLeft()
        {
            if (KeyBindings.IsEventActivated(Events.MoveLeft))
                return true;
            else
                return false;
        }

        public bool CheckMoveRight()
        {
            if (KeyBindings.IsEventActivated(Events.MoveRight))
                return true;
            else
                return false;
        }

        public bool CheckJump()
        {
            if (KeyBindings.IsEventActivated(Events.Jump))
                return true;
            else
                return false;
        }

        public bool CheckRestart()
        {
            if (KeyBindings.IsEventActivated(Events.Restart))
                return true;
            else
                return false;
        }

        public bool CheckQuit()
        {
            if (KeyBindings.IsEventActivated(Events.Quit))
                return true;
            else
                return false;
        }

        public bool CheckPause()
        {
            if (KeyBindings.IsEventActivated(Events.Pause))
                return true;
            else
                return false;
        }

        public bool CheckMouseLeft()
        {
            if (_mouseStateCurrent.LeftButton == ButtonState.Pressed &&
                _mouseStatePrevious.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Point CheckMousePosition()
        {
            return _mousePosition;
        }
    }
}
