// **********************************************************************************
// Filename					- Level.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace LemmingsPyGame.Models
{
    public class Level
    {
        private Bitmap _background;
        private Color _backgroundColor;

        public Level(Bitmap background)
        {
            _background = background;
            _backgroundColor = Color.FromArgb(255, 114, 114, 201);
        }

        public bool GroundAtPosition(Point position)
        {
            return _background.GetPixel(position.X, position.Y) != _backgroundColor;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(_background, 0, 0);
        }
    }
}
