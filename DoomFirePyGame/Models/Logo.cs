using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomFirePyGame.Models
{
    public class Logo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Image Img { get; set; }
        public int YFinal { get; set; }
        public int Step { get; set; }

        public Logo(int x, int y, Image sprite, int yFinal, int step)
        {
            X = x;
            Y = y;
            Img = sprite;
            YFinal = yFinal;
            Step = step;
        }

        public bool NeedsMoreScrolling => Y >= YFinal;

        public void Scroll()
        {
            Y += Step;
        }
    }
}
