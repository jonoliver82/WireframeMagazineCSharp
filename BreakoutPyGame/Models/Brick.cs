// **********************************************************************************
// Filename					- Brick.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace BreakoutPyGame.Models
{
    public class Brick : IDisposable
    {
        private SolidBrush _brush;
        private Pen _pen;

        private bool _disposedValue = false;

        public Brick(int x, int y, int width, int height)
        {
            Rect = new Rectangle(x, y, width, height);

            _brush = new SolidBrush(Color.White);
            _pen = new Pen(Color.White);
        }

        public Rectangle Rect { get; set; }

        public Brush ColorBrush => _brush;

        public Pen HighlightPen => _pen;

        public Point BottomLeft => new Point(Rect.Left, Rect.Bottom);

        public Point TopLeft => new Point(Rect.Left, Rect.Top);

        public Point TopRight => new Point(Rect.Right, Rect.Top);

        public int CenterX => Rect.X + (Rect.Width / 2);

        public int CenterY => Rect.Y + (Rect.Height / 2);

        public void SetColor(Color newColor)
        {
            if (_brush.Color != newColor)
            {
                _brush.Color = newColor;
            }
        }

        public void SetHighlight(Color newColor)
        {
            if (_pen.Color != newColor)
            {
                _pen.Color = newColor;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _pen.Dispose();
                    _brush.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
