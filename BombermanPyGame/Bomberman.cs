// **********************************************************************************
// Filename					- Bomberman.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using BombermanPyGame.Interfaces;
using BombermanPyGame.Models;
using Core;
using Core.Extensions;
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
            IPlayerFactory playerFactory,
            ITileFactory tileFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _tileFactory = tileFactory;
            _player = playerFactory.Create(0, 0);
            PopulateTileMap();
        }

        public override void KeyDown(Keys keyCode)
        {
            // Call base class first to set KeyboardState
            base.KeyDown(keyCode);

            // Store new temporary player position
            var newX = _player.X;
            var newY = _player.Y;

            // Update new position using keyboard
            if ((KeyboardState[Keys.Left] || KeyboardState[Keys.A]) && _player.X > 0)
            {
                newX -= 1;
            }
            else if ((KeyboardState[Keys.Right] || KeyboardState[Keys.D]) && _player.X < MAP_SIZE - 1)
            {
                newX += 1;
            }
            else if ((KeyboardState[Keys.Up] || KeyboardState[Keys.W]) && _player.Y > 0)
            {
                newY -= 1;
            }
            else if ((KeyboardState[Keys.Down] || KeyboardState[Keys.S]) && _player.Y < MAP_SIZE - 1)
            {
                newY += 1;
            }

            // Move player to new position if allowed
            if (_tileMap.CanMoveToPosition(newX, newY))
            {
                _player.X = newX;
                _player.Y = newY;
            }

            // Space key to place bomb
            if (KeyboardState[Keys.Space])
            {
                _tileMap.SetBomb(_player.X, _player.Y);
            }
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
            // Iterate through each tile in the tilemap
            for (int x = 0; x < MAP_SIZE; x++)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    _tileMap.DecrementTimer(x, y);

                    // Process tile types on timer finish
                    if (_tileMap.TimerExpired(x, y))
                    {
                        ProcessTimerExpired(x, y);
                    }
                }
            }
        }

        private void ProcessTimerExpired(int x, int y)
        {
            // Explosions eventually become ground
            if (_tileMap.IsExplosion(x, y))
            {
                _tileMap.SetGround(x, y);
            }

            // Bombs eventually create explosions
            if (_tileMap.IsBomb(x, y))
            {
                GenerateExplosionsFromOrigin(x, y);

                // Remove bomb
                _tileMap.SetExplosion(x, y);
            }
        }

        private void GenerateExplosionsFromOrigin(int x, int y)
        {
            // bombs radiate out in all 4 directions
            for (int angleDegrees = 0; angleDegrees < 360; angleDegrees += 90)
            {
                var cosA = (int)Math.Cos(MathExtensions.Radians(angleDegrees));
                var sinA = (int)Math.Sin(MathExtensions.Radians(angleDegrees));

                // RANGE determines bomb reach
                for (int range = 1; range < BOMB_RANGE; range++)
                {
                    var xOffset = range * cosA;
                    var yOffset = range * sinA;

                    // Only create explosions within the tilemap boundrary, and only on ground and brick tiles
                    if (_tileMap.CanCreateExplosion(x + xOffset, y + yOffset))
                    {
                        _tileMap.SetExplosion(x + xOffset, y + yOffset);
                    }
                    else
                    {
                        break;
                    }
                }
            }
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
