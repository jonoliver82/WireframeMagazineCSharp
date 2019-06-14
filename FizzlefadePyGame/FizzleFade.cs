using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Drawing;
using FizzlefadePyGame.Models;

namespace FizzlefadePyGame
{
    public class FizzleFade : PyGame
    {
        private const int WIDTH = 320;
        private const int HEIGHT = 200;

        private Fizzle _fizzle;

        private Bitmap _backBuffer;

        public FizzleFade(ITimerFactory timerFactory) 
            : base(WIDTH, HEIGHT, timerFactory)
        {
            _fizzle = new Fizzle(WIDTH, HEIGHT);
            _fizzle.Setup();

            _backBuffer = new Bitmap(WIDTH, HEIGHT);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_backBuffer, 0, 0);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _fizzle.UpdateFizzlePixels(_backBuffer);
        }
    }
}
