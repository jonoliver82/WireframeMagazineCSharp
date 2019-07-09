// **********************************************************************************
// Filename					- Bomberman.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Interfaces;
using BombermanPyGame.Models;
using Core;
using Core.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BombermanPyGame
{
    public class Bomberman : KeyboardPyGame
    {
        // TODO 10?
        private const int SIZE = 9;

        private const int WIDTH = (SIZE * 45) - 5;
        private const int HEIGHT = (SIZE * 45) - 5;

        private const int BOMB_RANGE = 3;

        private readonly ITileFactory _tileFactory;

        private Player _player;
        private Tile[,] _tilemap;

        public Bomberman(ITimerFactory timerFactory,
            ISpriteService spriteService,
            ITileFactory tileFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _tileFactory = tileFactory;

            // TODO: consider Player factory
            var playerSprite = spriteService.LoadImage("player.png");
            _player = new Player(playerSprite, 0, 0);

            PopulateTileMap();
        }

        private void PopulateTileMap()
        {
            _tilemap = new Tile[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (x % 2 == 1 && y % 2 == 1)
                    {
                        _tilemap[x, y] = _tileFactory.CreateWall();
                    }
                    else
                    {
                        _tilemap[x, y] = _tileFactory.CreateGround();
                    }
                }
            }
        }

        public override void KeyDown(Keys keyCode)
        {
            // TODO
            base.KeyDown(keyCode);
        }

        public override void Draw(Graphics g)
        {
            // TODO
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // TODO
        }
    }
}
