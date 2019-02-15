using System.Drawing;

namespace DoomFire.Models
{
    public class Logo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Image Img { get; set; }
        public int YFinal { get; set; }
        public int Step { get; set; }

        public Logo(int x, int y, string filename)
        {
            X = x;
            Y = y;
            Img = Bitmap.FromFile(filename);
        }

        public bool NeedsMoreScrolling => Y >= YFinal;

        public void Scroll()
        {
            Y += Step;
        }
    }
}
