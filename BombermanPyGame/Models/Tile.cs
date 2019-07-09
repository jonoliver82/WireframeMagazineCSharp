using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanPyGame.Models
{
    public class Tile
    {
        private int _timer = 0;

        public Tile(int type, Image sprite)
        {
            Type = type;
            Sprite = sprite;
        }

        public int Type { get; set; }

        public Image Sprite { get; set; }

        // TODO: python code used images[type] to look up image from array
        // TODO: as type now has 2 attributes (number and image), consider creating a class per tile type with an abstract base class
        public void SetType(int type, Image sprite)
        {
            _timer = 0;
            Type = type;
            Sprite = sprite;
        }
    }
}
