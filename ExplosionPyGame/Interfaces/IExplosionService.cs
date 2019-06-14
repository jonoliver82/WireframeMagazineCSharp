using ExplosionPyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplosionPyGame.Interfaces
{
    public interface IExplosionService
    {
        IEnumerable<Particle> Particles { get; }

        void Add(int x, int y);

        void UpdateParticles(TimeSpan timeSinceLastUpdate);
    }
}
