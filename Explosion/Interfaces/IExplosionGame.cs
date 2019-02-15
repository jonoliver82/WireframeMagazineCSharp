using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Explosion.Interfaces
{
    public interface IExplosionGame : IGame
    {
        void ExplodeRandom();
    }
}
