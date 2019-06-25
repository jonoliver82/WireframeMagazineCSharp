// **********************************************************************************
// Filename					- IExplosionService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ExplosionPyGame.Models;
using System;
using System.Collections.Generic;

namespace ExplosionPyGame.Interfaces
{
    public interface IExplosionService
    {
        IEnumerable<Particle> Particles { get; }

        void Add(int x, int y);

        void UpdateParticles(TimeSpan timeSinceLastUpdate);
    }
}
