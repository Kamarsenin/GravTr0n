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
    }
}
