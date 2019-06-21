using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxScrollingPyGame.Models
{
    public class Layer
    {
        public Image Img { get; set; }

        public Point TopLeft { get; set; }

        public int ScrollSpeed { get; set; }
    }
}
