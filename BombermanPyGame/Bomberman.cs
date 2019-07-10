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
        private const int MAP_SIZE = 9;
        private const int TILE_SIZE = 45;

        private const int WIDTH = (MAP_SIZE * TILE_SIZE) - 5;
        private const int HEIGHT = (MAP_SIZE * TILE_SIZE) - 5;

        private const int BOMB_RANGE = 3;

        private readonly ITileFactory _tileFactory;

        private Player _player;
        private TileMap _tileMap;

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

        public override void KeyDown(Keys keyCode)
        {
            // TODO
            base.KeyDown(keyCode);
        }

        public override void Draw(Graphics g)
        {
            // Draw the tilemap
            for (int x = 0; x < MAP_SIZE; x++)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    g.DrawImage(_tileMap.GetImage(x, y), x * TILE_SIZE, y * TILE_SIZE);
                }
            }

            // Draw the player
            g.DrawImage(_player.Sprite, _player.X * TILE_SIZE, _player.Y * TILE_SIZE);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // TODO
        }

        private void PopulateTileMap()
        {
            _tileMap = new TileMap(MAP_SIZE, MAP_SIZE);
            _tileMap.Initialise(MAP_SIZE, MAP_SIZE, _tileFactory);
            _tileMap.SetBrick(3, 2);
            _tileMap.SetBrick(4, 7);
        }
    }
}
