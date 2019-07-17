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
        private const int DEFAULT_BRIGHTNESS = 100;
        private const int TRAIL_LENGTH = 2;

        private Point _currentPosition;
        private double _velocityX;
        private double _velocityY;
        private int _brightness;
        private double _speed;

        public Star(Point position, double velocityX, double velocityY)
        {
            _currentPosition = position;
            _velocityX = velocityX;
            _velocityY = velocityY;

            // Math.Hypot(*vel)
            // Return the Euclidean norm, sqrt(x*x + y*y). This is the length of the vector from the origin to point (x, y)
            _speed = Math.Sqrt((_velocityX * _velocityX) + (_velocityY * _velocityY));

            _brightness = DEFAULT_BRIGHTNESS;
        }

        public int Brightness
        {
            get
            {
                return _brightness;
            }

            set
            {
                _brightness = value;
            }
        }

        public double Speed => _speed;

        // TODO create a velocity type in core with x and y
        public double VelocityX
        {
            get
            {
                return _velocityX;
            }

            set
            {
                _velocityX = value;
            }
        }

        public double VelocityY
        {
            get
            {
                return _velocityY;
            }

            set
            {
                _velocityY = value;
            }
        }

        public Point CurrentPosition
        {
            get
            {
                return _currentPosition;
            }

            set
            {
                _currentPosition = value;
            }
        }

        public Point CalculateEndPosition(double warpFactor)
        {
            return new Point((int)(_currentPosition.X - (_velocityX * warpFactor * TRAIL_LENGTH / 60)),
                             (int)(_currentPosition.Y - (_velocityY * warpFactor * TRAIL_LENGTH / 60)));
        }
    }
}
