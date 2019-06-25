// **********************************************************************************
// Filename					- Particle.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace ExplosionPyGame.Models
{
    public class Particle
    {
        private static SolidBrush _brush = new SolidBrush(Color.FromArgb(255, 230, 128));

        public Particle(double x, double y, double velocityX, double velocityY, TimeSpan age)
        {
            X = x;
            Y = y;
            VelocityX = velocityX;
            VelocityY = velocityY;
            Age = age;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public TimeSpan Age { get; set; }

        public double VelocityX { get; set; }

        public double VelocityY { get; set; }

        public SolidBrush Brush => _brush;

        public double Drag => 0.8;
    }
}
