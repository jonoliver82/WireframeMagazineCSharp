// **********************************************************************************
// Filename					- ExplosionService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using Core.Models;
using ExplosionPyGame.Interfaces;
using ExplosionPyGame.Models;
using ExplosionPyGame.Options;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExplosionPyGame.Services
{
    public class ExplosionService : IExplosionService
    {
        private const int PARTICLES_PER_EXPLOSION = 100;

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
        public void Add(PointF position)
        {
            // these are new particles, so set their age to zero
            var age = TimeSpan.FromSeconds(0);

            // generate particles for the explosion
            for (int i = 0; i < PARTICLES_PER_EXPLOSION; i++)
            {
                // for each particle, generate a random angle and distance
                var angle = _random.NextDouble() * (2 * Math.PI);
                var radius = Math.Pow(_random.NextDouble(), 0.5);

                // convert angle and distance from the explosion point into x and y velocity for the particle
                var velocity = new Velocity(_options.Speed * radius * Math.Sin(angle), _options.Speed * radius * Math.Cos(angle));

                // add the particle's position, velocity and age to the array
                _particles.Add(new Particle(position, velocity, age));
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
                    // Do not add this particle to the list
                    continue;
                }

                // update the particle's velocity - they slow down over time
                var drag = Math.Pow(particle.Drag, timeSinceLastUpdate.TotalSeconds);
                var velocity = new Velocity(particle.Velocity.X * drag, particle.Velocity.Y * drag);

                // update the particle's position according to its velocity
                var position = new PointF((float)(particle.Position.X + (velocity.X * timeSinceLastUpdate.TotalSeconds)),
                                          (float)(particle.Position.Y + (velocity.Y * timeSinceLastUpdate.TotalSeconds)));

                // update the particle's age
                var age = particle.Age + timeSinceLastUpdate;

                // add the particle's new position, velocity and age to the new array
                newParticles.Add(new Particle(position, velocity, age));
            }

            // replace the current array with the new one
            _particles = newParticles;
        }
    }
}
