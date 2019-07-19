// **********************************************************************************
// Filename					- Ball.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System.Drawing;

namespace BreakoutPyGame.Models
{
    public class Ball
    {
        private static SolidBrush _brush = new SolidBrush(Color.White);

        private Rectangle _rect;

        public Ball(int x, int y, int width, int height)
        {
            _rect = new Rectangle(x, y, width, height);
            Velocity = new Velocity(0, 0);
        }

        public Point Center
        {
            get
            {
                return new Point(_rect.Left + (_rect.Width / 2), _rect.Top + (_rect.Height / 2));
            }

            set
            {
                _rect.Location = new Point(value.X - (_rect.Width / 2), value.Y - (_rect.Height / 2));
            }
        }

        public Rectangle Rect => _rect;

        public int Top
        {
            get { return _rect.Top; }
            set { _rect.Y = value; }
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

        public Velocity Velocity { get; set; }

        public Brush Brush => _brush;
    }
}
