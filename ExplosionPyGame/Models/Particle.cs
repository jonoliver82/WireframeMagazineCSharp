// **********************************************************************************
// Filename					- Particle.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System;
using System.Drawing;

namespace ExplosionPyGame.Models
{
    public class Particle
    {
        private const double DEFAULT_DRAG = 0.8;

        private static SolidBrush _brush = new SolidBrush(Color.FromArgb(255, 230, 128));

        public Particle(PointF position, Velocity velocity, TimeSpan age)
        {
            Position = position;
            Velocity = velocity;
            Age = age;
        }

        public PointF Position { get; }

        public Velocity Velocity { get; }

        public TimeSpan Age { get; }

        public SolidBrush Brush => _brush;

        public double Drag => DEFAULT_DRAG;
    }
}
