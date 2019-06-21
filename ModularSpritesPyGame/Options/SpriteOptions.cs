using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularSpritesPyGame.Options
{
    public class SpriteOptions
    {
        /// <summary>
        /// Pixels from one segment to the next
        /// </summary>
        public int SegmentSize { get; set; }

        /// <summary>
        /// Base direction for the tail (radians)
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// How much the phase differs in each tail piece (radians)
        /// </summary>
        public double PhaseStep { get; set; }

        /// <summary>
        /// How much of a wobble there is (radians)
        /// </summary>
        public double WobbleAmount { get; set; }

        /// <summary>
        /// How fast the wobble moves (radians per second)
        /// </summary>
        public double Speed { get; set; }
    }
}
