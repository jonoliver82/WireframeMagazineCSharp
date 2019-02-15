using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JumpPhysics.Models
{
    public class Player
    {
        public Image Sprite { get; set; }

        public Point Position { get; set; }

        public Size Size { get; set; }

        public double YVelocity { get; set; }

        public double JumpVelocity { get; set; }

        public double XVelocity { get; set; }

        public double Gravity { get; set; }
    }
}
