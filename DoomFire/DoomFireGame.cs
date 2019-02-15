using Core.Models;
using DoomFire.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DoomFire.Models;

namespace DoomFire
{
    public class DoomFireGame : IDoomFireGame
    {
        private readonly RenderInformation _renderInformation;
        private Logo _logo;
        private Fire _fire;
        private int _fireDrawOffset;

        public DoomFireGame(RenderInformation renderInformation)
        {
            _renderInformation = renderInformation;

            _fire = new Fire(640, 256)
            {
                ClearSpeed = 32,
                SpreadSpeed = 3,
            };

            _logo = new Logo(50, 540, "doom.png")
            {
                YFinal = 70,
                Step = -4,
            };

            _fireDrawOffset = _renderInformation.Height - _fire.FireHeight;
            _fire.SetupFirePixels();
        }

        public void Render(Graphics graphics)
        {
            _fire.UpdateFirePixels();

            DrawLogo(graphics);
            DrawFire(graphics);

            if (_logo.NeedsMoreScrolling)
            {
                _logo.Scroll();
            }
            else
            {
                _fire.StopFire();
            }
        }

        private void DrawLogo(Graphics g)
        {
            var destination = new Rectangle(_logo.X, _logo.Y, _renderInformation.Width - 100, _renderInformation.Height / 2);
            g.DrawImage(_logo.Img, destination);
        }

        private void DrawFire(Graphics g)
        {
            for (var y = 0; y < _fire.FireHeight; y++)
            {
                for (var x = 0; x < _fire.FireWidth; x++)
                {
                    var brush = _fire.GetPixelBrush(x, y);
                    // Equivalent of SetPixel
                    g.FillRectangle(brush, x, y + _fireDrawOffset, 1, 1);
                }
            }
        }
    }
}
