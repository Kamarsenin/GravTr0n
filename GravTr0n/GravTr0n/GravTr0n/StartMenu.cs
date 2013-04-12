using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GravTr0n
{
    class StartMenu
    {
        private AnimatedDrawable _menuButton1;
        private AnimatedDrawable _menuButton2;
        public GameState GameState { get; set; }
        public int GameStateCheck { get; set; }

        public StartMenu(Texture2D buttonArt, int screenWidth, int screenHeight, GameState gameState, int gameStateCheck)
        {
            Rectangle menuButton1Rect = new Rectangle(0, 0, 143, 98);
            _menuButton1 = new AnimatedDrawable(buttonArt, 5, menuButton1Rect, 0.1f);
            _menuButton1.Position = new Vector2(screenWidth / 2 - 70, screenHeight / 2 - 143);

            Rectangle menuButton2Rect = new Rectangle(0, 0, 143, 98);
            _menuButton2 = new AnimatedDrawable(buttonArt, 5, menuButton2Rect, 0.1f);
            _menuButton2.Position = new Vector2(screenWidth / 2 - 70, (screenHeight / 2 - 45));
            _menuButton2.StartingOffset = new Point(_menuButton2.StartingOffset.X, 98);

            GameState = gameState;
            GameStateCheck = gameStateCheck;
        }

        public void Update(GameTime gameTime, IInputService input)
        {
            _menuButton1.Update(gameTime);
            _menuButton2.Update(gameTime);

            if (input.CheckMouseLeft())
                MouseClicked(input.CheckMousePosition().X, input.CheckMousePosition().Y);
        }

        public void AddDraw(IDrawSprites renderer)
        {
            renderer.AddDrawable(_menuButton1);
            renderer.AddDrawable(_menuButton2);
        }

        public void RemoveDraw(IDrawSprites renderer)
        {
            renderer.RemoveDrawable(_menuButton1);
            renderer.RemoveDrawable(_menuButton2);
        }

        private void MouseClicked(int x, int y)
        {
            Rectangle mouseClickRect = new Rectangle(x, y, 10, 10);
            Rectangle menuButton1Rect = new Rectangle((int)_menuButton1.Destination.X, (int)_menuButton1.Destination.Y, 143, 98);
            Rectangle menuButton2Rect = new Rectangle((int)_menuButton2.Destination.X, (int)_menuButton2.Destination.Y, 143, 98);

            if (mouseClickRect.Intersects(menuButton1Rect))
            {    
                GameState = GameState.Playing;
                GameStateCheck = 1;
            }
            else if (mouseClickRect.Intersects(menuButton2Rect))
            {
                GameState = GameState.Quit;
                GameStateCheck = -99;
            }
            
        }
    }
}
