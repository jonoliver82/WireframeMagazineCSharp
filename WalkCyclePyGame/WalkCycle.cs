// **********************************************************************************
// Filename					- WalkCycle.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;
using WalkCyclePyGame.Interfaces;
using WalkCyclePyGame.Models;

namespace WalkCyclePyGame
{
    public class WalkCycle : KeyboardPyGame
    {
        private const int WIDTH = 800;
        private const int HEIGHT = 300;

        private Player _player;

        public WalkCycle(IPlayerFactory playerFactory, ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _player = playerFactory.Create(new Point(375, 100));
        }

        public override void Draw(Graphics g)
        {
            _player.Draw(g);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            if (KeyboardState[Keys.Left] || KeyboardState[Keys.A])
            {
                if (_player.X > 10)
                {
                    _player.Left();
                }
            }
            else if (KeyboardState[Keys.Right] || KeyboardState[Keys.D])
            {
                if (_player.X < WIDTH - 80)
                {
                    _player.Right();
                }
            }
            else
            {
                _player.Stand();
            }

            _player.Update();
        }
    }
}
