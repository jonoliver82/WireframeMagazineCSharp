using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders.Interfaces
{
    public interface IInvadersGame : IGame
    {
        void CreateRandomShot();
    }
}
