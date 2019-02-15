using Explosion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explosion.Interfaces
{
    public interface IExplosionService
    {
        IEnumerable<Particle> Particles { get; }

        void Add(int x, int y);

        void UpdateParticles(TimeSpan timeSinceLastUpdate);
    }
}
