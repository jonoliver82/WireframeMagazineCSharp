// **********************************************************************************
// Filename					- ExplosionService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using ExplosionPyGame.Interfaces;
using ExplosionPyGame.Models;
using ExplosionPyGame.Options;
using System;
using System.Collections.Generic;

namespace ExplosionPyGame.Services
{
    public class ExplosionService : IExplosionService
    {
        private readonly IRandom _random;
        private readonly ExplosionOptions _options;

        private List<Particle> _particles;

        public ExplosionService(IRandom random, ExplosionOptions options)
        {
            _random = random;
            _options = options;

            _particles = new List<Particle>();
        }

        public IEnumerable<Particle> Particles => _particles;

        /// <summary>
        /// This function creates a new explosion at the specified screen co-ordinates.
        /// </summary>
        public void Add(int x, int y)
        {
            // these are new particles, so set their age to zero
            var age = TimeSpan.FromSeconds(0);

            // generate 100 particles per explosion
            for (int i = 0; i < 100; i++)
            {
                // for each particle, generate a random angle and distance
                var angle = _random.NextDouble() * (2 * Math.PI);
                var radius = Math.Pow(_random.NextDouble(), 0.5);

                // convert angle and distance from the explosion point into x and y velocity for the particle
                var vx = _options.Speed * radius * Math.Sin(angle);
                var vy = _options.Speed * radius * Math.Cos(angle);

                // add the particle's position, velocity and age to the array
                _particles.Add(new Particle(x, y, vx, vy, age));
            }
        }

        /// <summary>
        /// This function updates the array of particles.
        /// </summary>
        public void UpdateParticles(TimeSpan timeSinceLastUpdate)
        {
            // to update the particle array, create a new empty array
            var newParticles = new List<Particle>();

            // loop through the existing particle array
            foreach (var particle in _particles)
            {
                // if a particle was created more than a certain time ago, it can be removed
                if (particle.Age + timeSinceLastUpdate > TimeSpan.FromSeconds(_options.MaxAgeSeconds))
                {
                    continue;
                }

                // update the particle's velocity - they slow down over time
                var drag = Math.Pow(particle.Drag, timeSinceLastUpdate.TotalSeconds);
                var vx = particle.VelocityX * drag;
                var vy = particle.VelocityY * drag;

                // update the particle's position according to its velocity
                var x = particle.X + (vx * timeSinceLastUpdate.TotalSeconds);
                var y = particle.Y + (vy * timeSinceLastUpdate.TotalSeconds);

                // update the particle's age
                var age = particle.Age + timeSinceLastUpdate;

                // add the particle's new position, velocity and age to the new array
                newParticles.Add(new Particle(x, y, vx, vy, age));
            }

            // replace the current array with the new one
            _particles = newParticles;
        }
    }
}
