using ParallaxScrollingPyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxScrollingPyGame.Interfaces
{
    public interface ILayerFactory
    {
        Layer CreateBack();

        Layer CreateMiddle();

        Layer CreateFront();
    }
}
