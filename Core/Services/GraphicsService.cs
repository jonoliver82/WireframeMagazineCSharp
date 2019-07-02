// **********************************************************************************
// Filename					- GraphicsService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using Core.Interop;
using System;
using System.Drawing;

namespace Core.Services
{
    public class GraphicsService : IGraphicsService
    {
        /// <summary>
        /// Compares Colors without considering the value of the Alpha channel.
        /// </summary>
        public bool ColorRgbEquals(Color first, Color second)
        {
            return first.R == second.R && first.G == second.G && first.B == second.B;
        }

        /// <summary>
        /// Returns an RGB color from HSV
        /// https://stackoverflow.com/questions/359612/how-to-change-rgb-color-to-hsv/1626175#1626175
        /// </summary>
        public Color HsvToRgbColor(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = (hue / 60) - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - (f * saturation)));
            int t = Convert.ToInt32(value * (1 - ((1 - f) * saturation)));

            if (hi == 0)
            {
                return Color.FromArgb(255, v, t, p);
            }
            else if (hi == 1)
            {
                return Color.FromArgb(255, q, v, p);
            }
            else if (hi == 2)
            {
                return Color.FromArgb(255, p, v, t);
            }
            else if (hi == 3)
            {
                return Color.FromArgb(255, p, q, v);
            }
            else if (hi == 4)
            {
                return Color.FromArgb(255, t, p, v);
            }
            else
            {
                return Color.FromArgb(v, p, q);
            }
        }

        public Color GetScreenColorAtPosition(Graphics g, Point position)
        {
            IntPtr hdc = IntPtr.Zero;
            try
            {
                hdc = g.GetHdc();
                var color = GDI.GetPixel(hdc, position.X, position.Y);
                return Color.FromArgb((int)color);
            }
            finally
            {
                g.ReleaseHdc(hdc);
            }
        }
    }
}
