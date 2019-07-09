// **********************************************************************************
// Filename					- Bomberman.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using System;
using System.Drawing;

namespace BombermanPyGame
{
    public class Bomberman : KeyboardPyGame
    {
        private const int SIZE = 9;
        private const int WIDTH = (SIZE * 45) - 5;
        private const int HEIGHT = (SIZE * 45) - 5;

        public Bomberman(ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
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
