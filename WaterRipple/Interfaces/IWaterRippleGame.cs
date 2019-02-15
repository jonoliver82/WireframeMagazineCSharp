using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRipple.Interfaces
{
    public interface IWaterRippleGame : IMouseGame, IGame
    {
        void SplashRandom();
    }
}
