// **********************************************************************************
// Filename					- Layer.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace ParallaxScrollingPyGame.Models
{
    public class Layer
    {
        public Image Img { get; set; }

        public Point TopLeft { get; set; }

        public int ScrollSpeed { get; set; }
    }
}
