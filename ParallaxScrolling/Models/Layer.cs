using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ParallaxScrolling.Models
{
    public class Layer
    {
        public Image Img { get; set; }

        public Point TopLeft { get; set; }

        public int ScrollSpeed { get; set; }
    }
}
