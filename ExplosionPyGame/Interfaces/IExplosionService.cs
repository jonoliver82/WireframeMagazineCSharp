// **********************************************************************************
// Filename					- IExplosionService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ExplosionPyGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExplosionPyGame.Interfaces
{
    public interface IExplosionService
    {
        IEnumerable<Particle> Particles { get; }

        void Add(PointF position);

        void UpdateParticles(TimeSpan timeSinceLastUpdate);
    }
}
