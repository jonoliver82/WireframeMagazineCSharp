using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThrusterMotion.Models
{
    public class Spaceship
    {
        public Image NormalImage { get; set; }
        public Image ThrustImage { get; set; }
        public Point Position { get; set; }
        public float Angle { get; set; }
        public double Acceleration { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }

        public float TurnSpeed { get; set; }

        public Image CurrentImage { get; set; }
    }
}
