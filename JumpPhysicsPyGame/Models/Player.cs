using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpPhysicsPyGame.Models
{
    public class Player
    {
        public Player(int x, int y, Image sprite, int width, int height, double jumpVelocity, double xVelocity, double yVelocity, double gravity)
        {
            Position = new Point(x, y);
            Sprite = sprite;
            Size = new Size(width, height);
            JumpVelocity = jumpVelocity;
            XVelocity = xVelocity;
            YVelocity = yVelocity;
            Gravity = gravity;
        }

        public Image Sprite { get; set; }

        public Point Position { get; set; }

        public Size Size { get; set; }

        public double YVelocity { get; set; }

        public double JumpVelocity { get; set; }

        public double XVelocity { get; set; }

        public double Gravity { get; set; }
    }
}
