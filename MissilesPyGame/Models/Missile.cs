using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissilesPyGame.Models
{
    public class Missile
    {
        private const int GRAVITY = 5;
        private const int TRAIL_LENGTH = 1000;
        private const int TRAIL_BRIGHTNESS = 100;
        private Color FLARE_COLOR = Color.FromArgb(255, 220, 160);

        private const int SPEED = 4;

        private float _x;
        private float _y;
        private float _vx;
        private float _vy;
        private int _maxHeight;

        private TimeSpan _timeSpan;
        private Brush _flareBrush;
        private Pen _flarePen;

        private LinkedList<PointF> _trail;

        public Missile(float x, float vx, TimeSpan timeSpan, int maxHeight)
        {
            _x = x;
            _vx = vx;
            _timeSpan = timeSpan;
            _y = 0;
            _vy = 20;
            _maxHeight = maxHeight;

            _trail = new LinkedList<PointF>();
            _flareBrush = new SolidBrush(FLARE_COLOR);
            _flarePen = new Pen(FLARE_COLOR);
        }

        public void Update(TimeSpan timeSinceLastUpdate)
        {
            _timeSpan += timeSinceLastUpdate;
            var uy = _vy;

            // Increase y velocity
            _vy += (float)(GRAVITY * (timeSinceLastUpdate.TotalSeconds * SPEED));

            // Calculate new y position
            _y += (float)(1.0 * (uy + _vy) * (timeSinceLastUpdate.TotalSeconds * SPEED));

            // Calcualte new x position
            _x += (float)(_vx * (timeSinceLastUpdate.TotalSeconds * SPEED));

            _trail.AddFirst(new PointF(_x, _y));
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

            g.FillEllipse(_flareBrush, new RectangleF(_x - 2, _y - 2, 4, 4));

            // This small flickering lens flare makes it look like the missile's exhaust is very bright
            var flareLength = (float)(4 + Math.Sin(_timeSpan.TotalSeconds) * 2 + Math.Sin(_timeSpan.TotalSeconds * 5) * 1);
            g.DrawLine(_flarePen,
                new PointF(_x - flareLength, _y),
                new PointF(_x + flareLength, _y));
        }
    }
}
