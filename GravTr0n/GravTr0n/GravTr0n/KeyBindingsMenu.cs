using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    class KeyBindingsMenu
    {
        private AnimatedDrawable _keys;
        private AnimatedDrawable _left;
        private AnimatedDrawable _right;
        private AnimatedDrawable _jump;
        private AnimatedDrawable _exit;
        private AnimatedDrawable _pause;
        private AnimatedDrawable _restart;
        private int dividedPosScreenX = 2;
        private int dividedPosScreenY = 3;
        private int seperateSprites = 47;
        private int offSetY = 47;

        public GameState GameState { get; set; }
        public int GameStateCheck { get; set; }

        public KeyBindingsMenu(Texture2D keyBindingArt, int screenWidth, int screenHeight, GameState gameState, int gameStateCheck)
        {
            Rectangle _keysRect = new Rectangle(0, 0, 128, 46);
            _keys = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.2f);
            _keys.Position = new Vector2(screenWidth / dividedPosScreenX - 69, screenHeight / dividedPosScreenY - seperateSprites * 2);

            _left = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.1f);
            _left.Position = new Vector2(_keys.Position.X, _keys.Position.Y + seperateSprites);
            _left.StartingOffset = new Point(_left.StartingOffset.X, offSetY);

            _right = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.1f);
            _right.Position = new Vector2(_left.Position.X, _left.Position.Y + seperateSprites);
            _right.StartingOffset = new Point(_right.StartingOffset.X, _left.StartingOffset.Y + offSetY);

            _jump = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.1f);
            _jump.Position = new Vector2(_right.Position.X, _right.Position.Y + seperateSprites);
            _jump.StartingOffset = new Point(_jump.StartingOffset.X, _right.StartingOffset.Y + offSetY);

            _exit = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.1f);
            _exit.Position = new Vector2(_jump.Position.X, _jump.Position.Y + seperateSprites);
            _exit.StartingOffset = new Point(_exit.StartingOffset.X, _jump.StartingOffset.Y + offSetY);

            _pause = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.1f);
            _pause.Position = new Vector2(_exit.Position.X, _exit.Position.Y + seperateSprites);
            _pause.StartingOffset = new Point(_pause.StartingOffset.X, _exit.StartingOffset.Y + offSetY);

            _restart = new AnimatedDrawable(keyBindingArt, 4, _keysRect, 0.1f);
            _restart.Position = new Vector2(_pause.Position.X, _pause.Position.Y + seperateSprites);
            _restart.StartingOffset = new Point(_restart.StartingOffset.X, _pause.StartingOffset.Y + offSetY);

            GameState = gameState;
            GameStateCheck = gameStateCheck;
        }

        public void Update(GameTime gameTime, IInputService input)
        {
            _keys.Update(gameTime);
            _left.Update(gameTime);
            _right.Update(gameTime);
            _jump.Update(gameTime);
            _exit.Update(gameTime);
            _pause.Update(gameTime);
            _restart.Update(gameTime);

            if (input.CheckMouseLeft())
                MouseClicked(input.CheckMousePosition().X, input.CheckMousePosition().Y);
        }

        public void AddDraw(IDrawSprites renderer)
        {
            renderer.AddDrawable(_keys);
            renderer.AddDrawable(_left);
            renderer.AddDrawable(_right);
            renderer.AddDrawable(_jump);
            renderer.AddDrawable(_exit);
            renderer.AddDrawable(_pause);
            renderer.AddDrawable(_restart);
        }

        public void RemoveDraw(IDrawSprites renderer)
        {
            renderer.RemoveDrawable(_keys);
            renderer.RemoveDrawable(_left);
            renderer.RemoveDrawable(_right);
            renderer.RemoveDrawable(_jump);
            renderer.RemoveDrawable(_exit);
            renderer.RemoveDrawable(_pause);
            renderer.RemoveDrawable(_restart);
        }

        private void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle leftRect = new Rectangle((int)_left.Destination.X, (int)_left.Destination.Y, 128, 46);
            Rectangle rightRect = new Rectangle((int)_right.Destination.X, (int)_right.Destination.Y, 128, 46);
            Rectangle jumpRect = new Rectangle((int)_jump.Destination.X, (int)_jump.Destination.Y, 128, 46);
            Rectangle exitRect = new Rectangle((int)_exit.Destination.X, (int)_exit.Destination.Y, 128, 46);
            Rectangle pauseRect = new Rectangle((int)_pause.Destination.X, (int)_pause.Destination.Y, 128, 46);
            Rectangle restartRect = new Rectangle((int)_restart.Destination.X, (int)_restart.Destination.Y, 128, 46);

            if (mouseClickRect.Intersects(leftRect))
            {
                //GameState = GameState.Playing;
                //GameStateCheck = 1;
                //SETT INN VERDIER HER
            }
            else if (mouseClickRect.Intersects(rightRect))
            {
                //GameState = GameState.Quit;
                //GameStateCheck = -99;
                //VERDIER HER PL0x
            }

        }
    }
}
