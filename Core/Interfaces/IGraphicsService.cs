using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGraphicsService
    {
        bool ColorRgbEquals(Color first, Color second);

        Color GetScreenColorAtPosition(Graphics g, Point position);
    }
}
