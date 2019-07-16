// **********************************************************************************
// Filename					- Star.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace StarsPyGame.Models
{
    public class Star
    {
        private const int DEFAULT_BRIGHTNESS = 10;
        private const int TRAIL_LENGTH = 2;
        private const double MIN_WARP_FACTOR = 0.1;

        private Point _currentPosition;
        private double _velocityX;
        private double _velocityY;
        private int _brightness;
        private double _speed;

        // TODO remove warp factor from star and maintain in stars
        // when it is set use visitor pattern to update value in all stars?
        private double _warpFactor;

        public Star(Point position, double velocityX, double velocityY)
        {
            _currentPosition = position;
            _velocityX = velocityX;
            _velocityY = velocityY;

            // Math.Hypot(*vel)
            // Return the Euclidean norm, sqrt(x*x + y*y). This is the length of the vector from the origin to point (x, y)
            _speed = Math.Sqrt((_velocityX * _velocityX) + (_velocityY * _velocityY));

            _brightness = DEFAULT_BRIGHTNESS;
            _warpFactor = MIN_WARP_FACTOR;
        }

        public int Brightness => _brightness;

        public Point CurrentPosition => _currentPosition;

        public Point EndPosition
        {
            get
            {
                return new Point((int)(_currentPosition.X - (_velocityX * _warpFactor * TRAIL_LENGTH / 60)),
                                 (int)(_currentPosition.Y - (_velocityY * _warpFactor * TRAIL_LENGTH / 60)));
            }
        }
    }
}
