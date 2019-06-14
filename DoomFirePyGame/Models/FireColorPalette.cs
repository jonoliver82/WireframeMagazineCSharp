using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomFirePyGame.Models
{
    public static class FireColorPalette
    {
        private static SolidBrush[] _palette = new SolidBrush[]
        {
            new SolidBrush(Color.FromArgb(0x00, 0x07, 0x07, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x1F, 0x07, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x2F, 0x0F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x47, 0x0F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x57, 0x17, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x67, 0x1F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x77, 0x1F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x8F, 0x27, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0x9F, 0x2F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xAF, 0x3F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xBF, 0x47, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xC7, 0x47, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xDF, 0x4F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xDF, 0x57, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xDF, 0x57, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xD7, 0x5F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xD7, 0x5F, 0x07)),
            new SolidBrush(Color.FromArgb(0xFF, 0xD7, 0x67, 0x0F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xCF, 0x6F, 0x0F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xCF, 0x77, 0x0F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xCF, 0x7F, 0x0F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xCF, 0x87, 0x17)),
            new SolidBrush(Color.FromArgb(0xFF, 0xC7, 0x87, 0x17)),
            new SolidBrush(Color.FromArgb(0xFF, 0xC7, 0x8F, 0x17)),
            new SolidBrush(Color.FromArgb(0xFF, 0xC7, 0x97, 0x1F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xBF, 0x9F, 0x1F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xBF, 0x9F, 0x1F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xBF, 0xA7, 0x27)),
            new SolidBrush(Color.FromArgb(0xFF, 0xBF, 0xA7, 0x27)),
            new SolidBrush(Color.FromArgb(0xFF, 0xBF, 0xAF, 0x2F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xB7, 0xAF, 0x2F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xB7, 0xB7, 0x2F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xB7, 0xB7, 0x37)),
            new SolidBrush(Color.FromArgb(0xFF, 0xCF, 0xCF, 0x6F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xDF, 0xDF, 0x9F)),
            new SolidBrush(Color.FromArgb(0xFF, 0xEF, 0xEF, 0xC7)),
            new SolidBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF)),
        };

        public static SolidBrush[] Palette => _palette;

        public static int IndexWhite => 36;

        public static int IndexBlack => 0;
    }
}
