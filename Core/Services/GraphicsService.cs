using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Core.Interop;

namespace Core.Services
{
    public class GraphicsService : IGraphicsService
    {
        /// <summary>
        /// Compares Colors without considering the value of the Alpha channel
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
