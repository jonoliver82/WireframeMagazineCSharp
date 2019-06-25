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
