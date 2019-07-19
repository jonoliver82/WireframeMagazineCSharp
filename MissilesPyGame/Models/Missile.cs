// **********************************************************************************
// Filename					- Missile.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MissilesPyGame.Models
{
    public class Missile : IDisposable
    {
        private const int GRAVITY = 5;
        private const int TRAIL_LENGTH = 1000;
        private const int TRAIL_BRIGHTNESS = 100;
        private const int DEFAULT_POSITION_Y = 0;
        private const int DEFAULT_VELOCITY_Y = 20;

        private const int SPEED = 4;

        private Color _flareColor = Color.FromArgb(255, 220, 160);

        private PointF _position;
        private Velocity _velocity;

        private int _maxHeight;

        private TimeSpan _timeSpan;
        private Brush _flareBrush;
        private Pen _flarePen;

        private LinkedList<PointF> _trail;

        private bool _disposedValue = false;

        public Missile(float x, float velocityX, TimeSpan timeSpan, int maxHeight)
        {
            _position = new PointF(x, DEFAULT_POSITION_Y);
            _velocity = new Velocity(velocityX, DEFAULT_VELOCITY_Y);

            _timeSpan = timeSpan;
            _maxHeight = maxHeight;

            _trail = new LinkedList<PointF>();
            _flareBrush = new SolidBrush(_flareColor);
            _flarePen = new Pen(_flareColor);
        }

        public void Update(TimeSpan timeSinceLastUpdate)
        {
            _timeSpan += timeSinceLastUpdate;
            var uy = _velocity.Y;

            // Increase y velocity
            _velocity.Y += (float)(GRAVITY * (timeSinceLastUpdate.TotalSeconds * SPEED));

            // Calculate new y position
            _position.Y += (float)(1.0 * (uy + _velocity.Y) * (timeSinceLastUpdate.TotalSeconds * SPEED));

            // Calcualte new x position
            _position.X += (float)(_velocity.X * (timeSinceLastUpdate.TotalSeconds * SPEED));

            _trail.AddFirst(_position);
        }

        public bool IsTrailOffBottomOfScreen()
        {
            return _trail.First().Y > _maxHeight;
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < _trail.Count - 1; i++)
            {
                var start = _trail.ElementAt(i);
                var end = _trail.ElementAt(i + 1);

                // Linear scales from 100 to 0 over 1600 entries ie gray to black
                var colorPart = (int)(TRAIL_BRIGHTNESS * (1.0 - ((double)i / TRAIL_LENGTH)));

                if (colorPart < 0)
                {
                    colorPart = 0;
                }

                var color = Color.FromArgb(colorPart, colorPart, colorPart);
                var pen = new Pen(color);
                g.DrawLine(pen, start, end);
            }

            g.FillEllipse(_flareBrush, new RectangleF(_position.X - 2, _position.Y - 2, 4, 4));

            // This small flickering lens flare makes it look like the missile's exhaust is very bright
            var flareLength = (float)(4 + (Math.Sin(_timeSpan.TotalSeconds) * 2) + (Math.Sin(_timeSpan.TotalSeconds * 5) * 1));
            g.DrawLine(_flarePen,
                new PointF(_position.X - flareLength, _position.Y),
                new PointF(_position.X + flareLength, _position.Y));
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
                    _flarePen.Dispose();
                    _flareBrush.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
