﻿using Core.Models;
using System.Drawing;

namespace Fizzlefade.Models
{
    public class Fizzle
    {
        private readonly RenderInformation _renderInformation;

        private uint _rndval;
        private ushort _x;
        private ushort _y;
        private bool _done;

        public Fizzle(RenderInformation renderInformation)
        {
            _renderInformation = renderInformation;
        }

        public void Setup()
        {
            _rndval = 1;
            _x = 0;
            _y = 0;
            _done = false;
        }

        public void UpdateFizzlePixels(Bitmap buffer)
        {
            if (!_done)
            {
                // Y = low 8 bits
                _y = (ushort)(_rndval & 0x000FF);

                // X = High 9 bits
                _x = (ushort)((_rndval & 0x1FF00) >> 8);

                // Get the output bit
                var lsb = _rndval & 1;

                // Shift register
                _rndval >>= 1;

                // If the output is 0, the xor can be skipped
                if (lsb != 0)
                {
                    _rndval ^= 0x00012000;
                }

                if (_x < _renderInformation.Width && _y < _renderInformation.Height)
                {
                    buffer.SetPixel(_x, _y, Color.Red);
                }

                if (_rndval == 1)
                {
                    _done = true;
                }
            }
        }
    }
}
