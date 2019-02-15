using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularSprites.Models
{
    public class TailPiece : Tail
    {
        public TailPiece()
            : base(Bitmap.FromFile("tail_piece.png"))
        {
        }
    }
}
