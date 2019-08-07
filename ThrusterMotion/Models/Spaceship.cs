// **********************************************************************************
// Filename					- Spaceship.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace ThrusterMotionPyGame.Models
{
    public class Spaceship
    {
        private readonly Point _startPosition;

        public Spaceship(Point startPosition, Image normalImage, Image thrustImage, double acceleration, float turnSpeed)
        {
            _startPosition = startPosition;
            Position = startPosition;

            NormalImage = normalImage;
            ThrustImage = thrustImage;

            Acceleration = acceleration;
            TurnSpeed = turnSpeed;
        }

        public Image NormalImage { get; private set; }

        public Image ThrustImage { get; private set; }

        public Point Position { get; private set; }

        public float Angle { get; private set; }

        public double Acceleration { get; private set; }

        public double XSpeed { get; private set; }

        public double YSpeed { get; private set; }

        public float TurnSpeed { get; private set; }

        public bool IsThrusting { get; set; }

        public Image CurrentImage
        {
            get
            {
                return IsThrusting ? ThrustImage : NormalImage;
            }
        }

        public void Reset()
        {
            Position = _startPosition;
            XSpeed = 0;
            YSpeed = 0;
            Angle = 0;
            IsThrusting = false;
        }

        public void Accelerate()
        {
            XSpeed += Math.Cos(Angle * (Math.PI / 180.0)) * Acceleration;
            YSpeed += Math.Sin(Angle * (Math.PI / 180.0)) * Acceleration;
        }

        public void UpdateAngle(float angle)
        {
            Angle = angle;
        }

        public void CalculatePosition()
        {
            // Use the x and y speed to update the spaceship position
            // subtract the y speed as co-ordinates go from top to bottom
            var newXPosition = (int)(Position.X + XSpeed);
            var newYPosition = (int)(Position.Y + YSpeed);
            Position = new Point(newXPosition, newYPosition);
        }
    }
}
