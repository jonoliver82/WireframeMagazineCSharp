// **********************************************************************************
// Filename					- Bat.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace BreakoutPyGame.Models
{
    public class Bat
    {
        private static SolidBrush _brush = new SolidBrush(Color.Pink);

        private Rectangle _rect;

        public Bat(int x, int y, int width, int height)
        {
            _rect = new Rectangle(x, y, width, height);
        }

        public int Left
        {
            get { return _rect.Left; }
            set { _rect.X = value; }
        }

        public int Right
        {
            get { return _rect.Right; }
            set { _rect.X = value - _rect.Width; }
        }

        public Brush Brush => _brush;

        public Rectangle Rect => _rect;

        public void SetCenterX(int x)
        {
            _rect.X = x - (_rect.Width / 2);
        }
    }
}
