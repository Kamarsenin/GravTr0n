using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GravTr0n
{
    class Level01
    {
        private List<DrawData> _levelObjects;

        public GameState GameState { get; set; }
        public int GameStateCheck { get; set; }

        private Texture2D _terrainArt;
        private Texture2D _enemyArt;

        private DrawData _floor01;
        private DrawData _floor02;
        private Player _player;

        public Level01(Texture2D terrainArt, Texture2D enemyArt, GameState gameState, int gameStateCheck, Player player)
        {
            _levelObjects = new List<DrawData>();
            _terrainArt = terrainArt;
            _enemyArt = enemyArt;
            GameState = gameState;
            GameStateCheck = gameStateCheck;
            _player = player;
            AddLevelObjects();
        }

        private void AddLevelObjects()
        {
            _levelObjects.Add(_player);
            _floor01 = new DrawData(_terrainArt, new Rectangle(0, 0, 67, 10));
            _floor01.Position = new Vector2(0, 200);
            _levelObjects.Add(_floor01);
            _floor02 = new DrawData(_terrainArt, new Rectangle(0, 0, 67, 10));
            _floor02.Position = new Vector2(68, 200);
            _levelObjects.Add(_floor02);


        }

        public void Update(ICollisionService collisionManager)
        {
            for (int i = 1; i < _levelObjects.Count; i++)
            {
                if (collisionManager.IsCollision(_player, _levelObjects[i]))
                {
                    collisionManager.ResolveCollision(_player, _levelObjects[i]);
                }
            }
        }

        public void AddDraw(IDrawSprites renderer)
        {
            foreach (DrawData item in _levelObjects)
            {
                renderer.AddDrawable(item);
            }
        }

        public void RemoveDraw(IDrawSprites renderer)
        {
            foreach (DrawData item in _levelObjects)
            {
                renderer.RemoveDrawable(item);
            }
        }
    }
}
