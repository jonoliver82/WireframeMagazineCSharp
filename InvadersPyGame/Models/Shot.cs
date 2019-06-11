using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvadersPyGame.Models
{
    public class Shot
    {
        public Image Sprite { get; set; }

        public Point Position { get; set; }

        public bool Exploding { get; set; }

        public int Timer { get; set; }
    }    
}
