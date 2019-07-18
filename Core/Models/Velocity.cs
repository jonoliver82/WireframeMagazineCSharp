// **********************************************************************************
// Filename					- Velocity.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;

namespace Core.Models
{
    public class Velocity
    {
        public Velocity(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public void UpdateVelocity(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void UpdateVelocity(TimeSpan interval)
        {
            X = X * Math.Pow(2, interval.TotalSeconds);
            Y = Y * Math.Pow(2, interval.TotalSeconds);
        }

        /// <summary>
        /// Return the Euclidean norm, sqrt(x*x + y*y). This is the length of the vector from the origin to point (x, y)
        /// Python: Math.Hypot(*vel)
        /// </summary>
        public double Speed()
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }
    }
}
