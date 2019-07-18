// **********************************************************************************
// Filename					- Star.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System;
using System.Drawing;

namespace StarsPyGame.Models
{
    public class Star
    {
        private const int DEFAULT_BRIGHTNESS = 100;
        private const int TRAIL_LENGTH = 2;

        private Point _startPosition;
        private Point _endPosition;
        private Velocity _velocity;
        private int _brightness;

        public Star(Point position, Velocity velocity)
        {
            _startPosition = position;
            _velocity = velocity;
            _brightness = DEFAULT_BRIGHTNESS;
        }

        public int Brightness => _brightness;

        public double Speed => _velocity.Speed();

        public Velocity Velocity => _velocity;

        public Point StartPosition => _startPosition;

        public Point EndPosition => _endPosition;

        public Color LineColor => Color.FromArgb(_brightness, _brightness, _brightness);

        public void UpdateVelocity(TimeSpan interval)
        {
            _velocity.UpdateVelocity(interval);
        }

        public void UpdateStartAndEndPositions(double warpFactor, TimeSpan interval)
        {
            _startPosition = new Point((int)(_startPosition.X + (_velocity.X * warpFactor * interval.TotalSeconds)),
                                       (int)(_startPosition.Y + (_velocity.Y * warpFactor * interval.TotalSeconds)));

            _endPosition = new Point((int)(_startPosition.X - (_velocity.X * warpFactor * TRAIL_LENGTH / 60)),
                                     (int)(_startPosition.Y - (_velocity.Y * warpFactor * TRAIL_LENGTH / 60)));
        }

        public void UpdateBrightness(double warpFactor, TimeSpan interval)
        {
            _brightness = (int)Math.Min(_brightness + (warpFactor * 200 * interval.TotalSeconds), Speed);

            // Clamp to 255 so can be used as a color component (RGB)
            _brightness = Math.Min(255, _brightness);
        }
    }
}
