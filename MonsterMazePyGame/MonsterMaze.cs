// **********************************************************************************
// Filename					- MonsterMaze.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using MonsterMazePyGame.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonsterMazePyGame
{
    public class MonsterMaze : KeyboardPyGame
    {
        private const int WIDTH = 600;
        private const int HEIGHT = 600;

        private const int MAP_WIDTH = 10;
        private const int MAP_HEIGHT = 10;

        private const int MAX_IMAGES = 4;

        private readonly Point _origin = new Point(0, 0);

        private int[,] _maze = new int[MAP_WIDTH, MAP_HEIGHT]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 0, 1, 0, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 0, 1, 0, 1, 1, 0, 1, 1 },
            { 1, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

        private Player _player;

        private int[] _directionX = new int[] { -1, 0, 1, 0 };
        private int[] _directionY = new int[] { 0, 1, 0, -1 };

        private Image _background;
        private Image[] _leftImages;
        private Image[] _midImages;
        private Image[] _rightImages;

        public MonsterMaze(ISpriteService spriteService, ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _background = spriteService.LoadImage("back.png");

            _player = new Player(new Point(1, 4), 2);

            // Pre-load the wall images
            _leftImages = spriteService.LoadImages("left0.png", "left1.png", "left2.png", "left3.png", "left4.png");
            _midImages = spriteService.LoadImages("mid0.png", "mid1.png", "mid2.png", "mid3.png", "mid4.png");
            _rightImages = spriteService.LoadImages("right0.png", "right1.png", "right2.png", "right3.png", "right4.png");
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_background, _origin);

            var directionMovement = 1;
            if (_player.Direction == 1 || _player.Direction == 3)
            {
                directionMovement = -1;
            }

            // There are images 0..4 inclusive.
            // The higher number images are further away.
            // The images are drawn back to front.
            for (int i = MAX_IMAGES; i >= 0; i--)
            {
                var x = _player.Position.X + (i * _directionX[_player.Direction]);
                var y = _player.Position.Y + (i * _directionY[_player.Direction]);

                if (x >= 0 && x < MAP_WIDTH && y >= 0 && y < MAP_HEIGHT)
                {
                    // Left image
                    var xLeft = x + (_directionY[_player.Direction] * directionMovement);
                    var yLeft = y + (_directionX[_player.Direction] * directionMovement);

                    if (_maze[xLeft, yLeft] == 1)
                    {
                        g.DrawImage(_leftImages[i], _origin);
                    }

                    // Right image
                    var xRight = x - (_directionY[_player.Direction] * directionMovement);
                    var yRight = y - (_directionX[_player.Direction] * directionMovement);

                    if (_maze[xRight, yRight] == 1)
                    {
                        g.DrawImage(_rightImages[i], _origin);
                    }

                    // Mid image
                    if (_maze[x, y] == 1)
                    {
                        g.DrawImage(_midImages[i], _origin);
                    }
                }
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            if (KeyboardState[Keys.Left] || KeyboardState[Keys.A])
            {
                _player.Direction -= 1;
                if (_player.Direction < 0)
                {
                    _player.Direction = 3;
                }
            }

            if (KeyboardState[Keys.Right] || KeyboardState[Keys.D])
            {
                _player.Direction += 1;
                if (_player.Direction > 3)
                {
                    _player.Direction = 0;
                }
            }

            if (KeyboardState[Keys.Up] || KeyboardState[Keys.W])
            {
                var newX = _player.Position.X + _directionX[_player.Direction];
                var newY = _player.Position.Y + _directionY[_player.Direction];

                if (_maze[newX, newY] == 0)
                {
                    _player.Position = new Point(newX, newY);
                }
            }

            if (KeyboardState[Keys.Down] || KeyboardState[Keys.S])
            {
                var newX = _player.Position.X - _directionX[_player.Direction];
                var newY = _player.Position.Y - _directionY[_player.Direction];

                if (_maze[newX, newY] == 0)
                {
                    _player.Position = new Point(newX, newY);
                }
            }
        }
    }
}
