using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fizzlefade.Interfaces;
using Core.Models;
using Fizzlefade.Models;

namespace Fizzlefade
{
    public class FizzlefadeGame : IFizzlefadeGame
    {
        private readonly RenderInformation _renderInformation;

        private Bitmap _backBuffer;

        private Fizzle _fizzle;

        public FizzlefadeGame(RenderInformation renderInformation)
        {
            _renderInformation = renderInformation;

            _fizzle = new Fizzle(_renderInformation);
            _fizzle.Setup();

            _backBuffer = new Bitmap(_renderInformation.Width, _renderInformation.Height);
        }

        public void Render(Graphics graphics)
        {
            _fizzle.UpdateFizzlePixels(_backBuffer);
            graphics.DrawImage(_backBuffer, 0, 0);
        }
    }
}
