using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Drawing;
using DoomFirePyGame.Models;
using DoomFirePyGame.Interfaces;

namespace DoomFirePyGame
{
    public class DoomFire : PyGame
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 509;

        private Fire _fire;
        private Logo _logo;

        public DoomFire(ILogoFactory logoFactory, ITimerFactory timerFactory) 
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _fire = new Fire(WIDTH, 256)
            {
                ClearSpeed = 32,
                SpreadSpeed = 3,
            };

            _logo = logoFactory.Create(50, 540);

            _fire.SetupFirePixels();
        }

        public override void Draw(Graphics g)
        {
            DrawLogo(g);
            DrawFire(g);

            if (_logo.NeedsMoreScrolling)
            {
                _logo.Scroll();
            }
            else
            {
                _fire.StopFire();
            }
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _fire.UpdateFirePixels();
        }

        private void DrawLogo(Graphics g)
        {
            var destination = new Rectangle(_logo.X, _logo.Y, WIDTH - 100, HEIGHT / 2);
            g.DrawImage(_logo.Img, destination);
        }

        private void DrawFire(Graphics g)
        {
            int fireDrawOffset = HEIGHT - _fire.FireHeight;

            for (var y = 0; y < _fire.FireHeight; y++)
            {
                for (var x = 0; x < _fire.FireWidth; x++)
                {
                    var brush = _fire.GetPixelBrush(x, y);
                    // Equivalent of SetPixel
                    g.FillRectangle(brush, x, y + fireDrawOffset, 1, 1);
                }
            }
        }
    }
}
