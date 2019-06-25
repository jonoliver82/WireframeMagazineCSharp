// **********************************************************************************
// Filename					- Explosion.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using ExplosionPyGame.Interfaces;
using System;
using System.Drawing;

namespace ExplosionPyGame
{
    public class Explosion : PyGame
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 480;

        private readonly IExplosionService _explosionService;
        private readonly IRandom _random;

        public Explosion(ITimerFactory timerFactory,
            IExplosionService explosionService,
            IRandom random)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _explosionService = explosionService;
            _random = random;

            ScheduleClockInterval(ExplodeRandom, 1500);
        }

        public override void Draw(Graphics g)
        {
            foreach (var particle in _explosionService.Particles)
            {
                g.FillRectangle(particle.Brush, (int)Math.Round(particle.X), (int)Math.Round(particle.Y), 1, 1);
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _explosionService.UpdateParticles(timeSinceLastUpdate);
        }

        /// <summary>
        /// This function creates an explosion at a random location on the screen.
        /// </summary>
        public void ExplodeRandom()
        {
            // select a random position on the screen
            var x = _random.Next(WIDTH);
            var y = _random.Next(HEIGHT);

            // call the explosion function for that position
            _explosionService.Add(x, y);
        }
    }
}
