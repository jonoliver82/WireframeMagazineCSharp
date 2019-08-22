// **********************************************************************************
// Filename					- IsometricMap.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace IsometricMapPyGame
{
    public class IsometricMap : KeyboardPyGame
    {
        private const int WIDTH = 600;
        private const int HEIGHT = 400;

        private const int MAP_START_X = 268;
        private const int MAP_START_Y = -64;

        private const int MAP_WIDTH = 20;
        private const int MAP_HEIGHT = 20;
        private const int MAP_DEPTH = 3;
        private const int SCROLL_SPEED = 2;

        private bool[,,] _mapBlocks;
        private Point _mapPosition;
        private Image _blockImage;

        public IsometricMap(ISpriteService spriteService, ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _blockImage = spriteService.LoadImage("block.png");

            _mapPosition = new Point(MAP_START_X, -MAP_START_Y);
            _mapBlocks = new bool[MAP_WIDTH, MAP_HEIGHT, MAP_DEPTH];

            InitialiseMap();
        }

        /// <summary>
        /// Draw the map to the window by drawing the blocks layer by layer.
        /// </summary>
        public override void Draw(Graphics g)
        {
            for (int z = 0; z < MAP_DEPTH; z++)
            {
                for (int x = 0; x < MAP_WIDTH; x++)
                {
                    for (int y = 0; y < MAP_HEIGHT; y++)
                    {
                        var blockX = (x * 32) - (y * 32) + _mapPosition.X;
                        var blockY = (y * 16) + (x * 16) - (z * 32) + _mapPosition.Y;

                        // Only display blocks that are in the window
                        if (IsInWindow(blockX, blockY))
                        {
                            if (_mapBlocks[x, y, z] == true)
                            {
                                g.DrawImage(_blockImage, new Point(blockX, blockY));
                            }
                        }
                    }
                }
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            if (KeyboardState[Keys.Left] || KeyboardState[Keys.A])
            {
                _mapPosition = new Point(_mapPosition.X - SCROLL_SPEED, _mapPosition.Y);
            }

            if (KeyboardState[Keys.Right] || KeyboardState[Keys.D])
            {
                _mapPosition = new Point(_mapPosition.X + SCROLL_SPEED, _mapPosition.Y);
            }

            if (KeyboardState[Keys.Up] || KeyboardState[Keys.W])
            {
                _mapPosition = new Point(_mapPosition.X, _mapPosition.Y - SCROLL_SPEED);
            }

            if (KeyboardState[Keys.Down] || KeyboardState[Keys.S])
            {
                _mapPosition = new Point(_mapPosition.X, _mapPosition.Y + SCROLL_SPEED);
            }
        }

        private void InitialiseProblemMap()
        {
            _mapBlocks[0, 0, 0] = true;
            _mapBlocks[1, 0, 0] = true;
            _mapBlocks[0, 1, 0] = true;
        }

        private void InitialiseMap()
        {
            // Map building section - make a border, some arches and some pyramids
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                for (int y = 0; y < MAP_HEIGHT; y++)
                {
                    if (x == 0 || x == MAP_WIDTH - 1 || y == 0 || y == MAP_HEIGHT - 1)
                    {
                        _mapBlocks[x, y, 0] = true;
                    }

                    if (x == 5 && (y == 4 || y == 13))
                    {
                        MakeArch(x, y);
                    }

                    if (x == 12 && y == 14)
                    {
                        MakeArch(x, y);
                    }

                    if ((x == 4 || x == 12) && (y == 7))
                    {
                        MakePyramid(x, y);
                    }
                }
            }

            // Make an entrance gap
            for (int i = 0; i < 5; i++)
            {
                _mapBlocks[i, 0, 0] = false;
            }
        }

        private bool IsInWindow(int blockX, int blockY)
        {
            // Python uses interval comparison for this
            // if -64 <= bx < WIDTH + 32 and -64 <= by < HEIGHT + 32:
            return (blockX >= -64) && (blockX < WIDTH + 32) && (blockY >= -64) && (blockY < HEIGHT + 32);
        }

        private void MakeArch(int x, int y)
        {
            for (int z = 0; z < MAP_DEPTH; z++)
            {
                _mapBlocks[x, y, z] = true;
                _mapBlocks[x, y + 2, z] = true;
            }

            _mapBlocks[x, y + 1, 2] = true;
        }

        private void MakePyramid(int x, int y)
        {
            for (int px = 0; px < 5; px++)
            {
                for (int py = 0; py < 5; py++)
                {
                    _mapBlocks[px + x, py + y, 0] = true;
                }
            }

            for (int px = 1; px < 4; px++)
            {
                for (int py = 1; py < 4; py++)
                {
                    _mapBlocks[px + x, py + y, 1] = true;
                }
            }

            _mapBlocks[x + 2, y + 2, 2] = true;
        }
    }
}
