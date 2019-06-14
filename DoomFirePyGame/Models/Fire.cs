using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomFirePyGame.Models
{
    public class Fire
    {
        private Random _random;

        /// <summary>
        /// Palette based framebuffer. Coordinate system origin upper-left.
        /// </summary>
        private int[] _firePixels;

        public int FireWidth { get; set; }

        public int FireHeight { get; set; }

        public int ClearSpeed { get; set; }
        public int SpreadSpeed { get; set; }

        public Fire(int width, int height)
        {
            FireWidth = width;
            FireHeight = height;

            _firePixels = new int[width * height];
            _random = new Random();
        }

        public void SetupFirePixels()
        {
            // Set whole screen to palette index 0 (#070707)
            for (int i = 0; i < _firePixels.Length; i++)
            {
                _firePixels[i] = FireColorPalette.IndexBlack;
            }

            // Set bottom line to palette index 37 (#FFFFFF) white
            for (int i = 0; i < FireWidth; i++)
            {
                _firePixels[(FireHeight - 1) * FireWidth + i] = FireColorPalette.IndexWhite;
            }
        }

        public void StopFire()
        {
            for (var y = (FireHeight - 1); y > (FireHeight - ClearSpeed); y--)
            {
                for (var x = 0; x < FireWidth; x++)
                {
                    var index = y * FireWidth + x;
                    if (_firePixels[index] > 0)
                    {
                        var rand = _random.Next(SpreadSpeed);
                        _firePixels[index] -= rand & SpreadSpeed;
                        if (_firePixels[index] < 0)
                        {
                            _firePixels[index] = 0;
                        }
                    }
                }
            }
        }

        public void UpdateFirePixels()
        {
            for (int x = 0; x < FireWidth; x++)
            {
                for (int y = 1; y < FireHeight; y++)
                {
                    SpreadFire(y * FireWidth + x);
                }
            }
        }

        private void SpreadFire(int src)
        {
            var pixel = _firePixels[src];
            if (pixel == 0)
            {
                _firePixels[src - FireWidth] = 0;
            }
            else
            {
                var rand = _random.Next(SpreadSpeed);
                var dst = (src - rand + 1) - FireWidth;
                if (dst < 0)
                {
                    dst = 0;
                }
                _firePixels[dst] = pixel - (rand & 1);
            }
        }

        public Brush GetPixelBrush(int x, int y)
        {
            var index = _firePixels[y * FireWidth + x];
            return FireColorPalette.Palette[index];
        }
    
    }
}
