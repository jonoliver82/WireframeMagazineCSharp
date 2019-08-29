using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMazePyGame.Models
{
    public class Player
    {
        public Player(Point startPosition, int startDirection)
        {
            Position = startPosition;
            Direction = startDirection;
        }

        public Point Position { get; set; }

        public int Direction { get; set; }
    }
}
