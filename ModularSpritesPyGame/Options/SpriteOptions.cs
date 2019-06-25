// **********************************************************************************
// Filename					- SpriteOptions.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

namespace ModularSpritesPyGame.Options
{
    public class SpriteOptions
    {
        /// <summary>
        /// Gets or sets pixels from one segment to the next.
        /// </summary>
        public int SegmentSize { get; set; }

        /// <summary>
        /// Gets or sets  the base direction for the tail (radians).
        /// </summary>
        public double Angle { get; set; }

        /// <summary>
        /// Gets or sets how much the phase differs in each tail piece (radians).
        /// </summary>
        public double PhaseStep { get; set; }

        /// <summary>
        /// Gets or sets how much of a wobble there is (radians).
        /// </summary>
        public double WobbleAmount { get; set; }

        /// <summary>
        /// Gets or sets how fast the wobble moves (radians per second).
        /// </summary>
        public double Speed { get; set; }
    }
}
