// **********************************************************************************
// Filename					- Logo.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace DoomFirePyGame.Models
{
    public class Logo
    {
        public Logo(int x, int y, Image sprite, int yFinal, int step)
        {
            X = x;
            Y = y;
            Img = sprite;
            YFinal = yFinal;
            Step = step;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Image Img { get; set; }

        public int YFinal { get; set; }

        public int Step { get; set; }

        public bool NeedsMoreScrolling => Y >= YFinal;

        public void Scroll()
        {
            Y += Step;
        }
    }
}
