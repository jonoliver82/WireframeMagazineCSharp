// **********************************************************************************
// Filename					- Stars.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using Core.Models;
using StarsPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StarsPyGame
{
    public class Stars : KeyboardPyGame
    {
        private const int WIDTH = 1000;
        private const int HEIGHT = 1000 * 9 / 16;

        private const int CENTER_X = WIDTH / 2;
        private const int CENTER_Y = HEIGHT / 2;

        // Warp factor per second
        private const double ACCEL = 1.0;

        // Fraction of speed per second
        private const double DRAG = 0.71;

        private const double MIN_WARP_FACTOR = 0.1;
        private const int TRAIL_LENGTH = 2;

        private static SolidBrush _warpBrush = new SolidBrush(Color.FromArgb(180, 160, 0));
        private static SolidBrush _instructionBrush = new SolidBrush(Color.FromArgb(90, 80, 0));

        private static Font _warpFont = new Font(FontFamily.GenericMonospace, 20.0f);
        private static Font _instructionFont = new Font(FontFamily.GenericMonospace, 14.0f);

        private static StringFormat _stringFormat = new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center,
        };

        private readonly IRandom _random;

        private List<Star> _starList;
        private double _warpFactor = MIN_WARP_FACTOR;

        public Stars(ITimerFactory timerFactory, IRandom random)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _random = random;
            _starList = new List<Star>();
            InitialiseStarField();
        }

        public override void Draw(Graphics g)
        {
            DrawStars(g);
            DrawHeadsUpDisplay(g);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // Calculate the new warp factor
            if (KeyboardState[Keys.Space])
            {
                _warpFactor += ACCEL * timeSinceLastUpdate.TotalSeconds * 10;
            }

            // Apply drag to slow us, regardless of whether space is held
            _warpFactor = MIN_WARP_FACTOR + ((_warpFactor - MIN_WARP_FACTOR) * Math.Pow(DRAG, timeSinceLastUpdate.TotalSeconds));

            // Spawn new stars until we have 300
            while (_starList.Count < 300)
            {
                // Pick a direction and speed
                var angle = _random.Next(-Math.PI, Math.PI);
                var speed = 255 * Math.Pow(_random.Next(0.3, 1.0), 2);

                // Turn the direction into position and velocity vectors
                var directionX = Math.Cos(angle);
                var directionY = Math.Sin(angle);
                var distance = _random.Next(25 + TRAIL_LENGTH, 100);
                var position = new Point((int)(CENTER_X + (directionX * distance)), (int)(CENTER_Y + (directionY * distance)));
                var velocity = new Velocity(speed * directionX, speed * directionY);

                _starList.Add(new Star(position, velocity));
            }

            // Update the positions of stars
            foreach (var star in _starList)
            {
                // Move according to speed and warp factor
                star.UpdateStartAndEndPositions(_warpFactor, timeSinceLastUpdate);

                // Grow brighter
                star.UpdateBrightness(_warpFactor, timeSinceLastUpdate);

                // Get faster
                star.UpdateVelocity(timeSinceLastUpdate);
            }

            // Drop any stars that are completely off-screen
            _starList.RemoveAll(star => IsOutsideScreenBounds(star.EndPosition));
        }

        private void InitialiseStarField()
        {
            // Jump-start the star field
            for (int i = 0; i < 30; i++)
            {
                Update(TimeSpan.FromSeconds(0.5), null);
            }

            for (int i = 0; i < 5; i++)
            {
                Update(TimeSpan.FromSeconds(1 / 60), null);
            }
        }

        private void DrawStars(Graphics g)
        {
            foreach (var star in _starList)
            {
                 var pen = new Pen(star.LineColor);
                 g.DrawLine(pen, star.StartPosition, star.EndPosition);
            }
        }

        private void DrawHeadsUpDisplay(Graphics g)
        {
            g.DrawString($"||| Warp {_warpFactor.ToString("F1")} |||", _warpFont, _warpBrush, new Point(WIDTH / 2, HEIGHT - 40), _stringFormat);
            g.DrawString($"Hold SPACE to accelerate", _instructionFont, _instructionBrush, new Point(WIDTH / 2, HEIGHT - 8), _stringFormat);
        }
    }
}
