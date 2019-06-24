using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRipplePyGame.Options
{
    public class WaterRippleOptions
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int InitialForce { get; set; }

        public int MaxForce { get; set; }

        public double Damping { get; set; }
    }
}
