// **********************************************************************************
// Filename					- FizzleFade.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using FizzlefadePyGame.Models;
using System;
using System.Drawing;

namespace FizzlefadePyGame
{
    public class FizzleFade : PyGame
    {
        private const int WIDTH = 320;
        private const int HEIGHT = 200;

        private Fizzle _fizzle;

        private Bitmap _backBuffer;

        public FizzleFade(ITimerFactory timerFactory)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _fizzle = new Fizzle(WIDTH, HEIGHT);
            _fizzle.Setup();

            _backBuffer = new Bitmap(WIDTH, HEIGHT);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_backBuffer, 0, 0);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _fizzle.UpdateFizzlePixels(_backBuffer);
        }
    }
}
