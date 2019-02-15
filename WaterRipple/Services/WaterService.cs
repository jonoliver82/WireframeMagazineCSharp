using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterRipple.Interfaces;

namespace WaterRipple.Services
{
    public class WaterService : IWaterService
    {
        private Bitmap _renderOutput;
        private Graphics _g;

        private double _damping = 0.99;

        private int _initialForce = 16000;
        private int _maxForce = 16000;

        private int[] _buffer1;
        private int[] _buffer2;

        private int[] _frontBuffer;
        private int[] _backBuffer;

        private int _width;
        private int _height;

        public WaterService(RenderInformation renderInformation)
        {
            _width = renderInformation.Width;
            _height = renderInformation.Height;

            _buffer1 = new int[_width * _height];
            _buffer2 = new int[_width * _height];

            _frontBuffer = _buffer1;
            _backBuffer = _buffer2;

            _renderOutput = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
            _g = Graphics.FromImage(_renderOutput);
        }

        public Bitmap RenderOutput => _renderOutput;

        public void Update()
        {
            ProcessBuffers(_backBuffer, _frontBuffer);
            SwapBuffers();
            Render();
        }

        private void ProcessBuffers(int[] source, int[] dest)
        {
            // Start at 1, and end at size - 1 to skip edge elements
            for (int y = 1; y < _height - 1; y++)
            {
                for (int x = 1; x < _width - 1; x++)
                {
                    var index = y * _width + x;

                    var v1 = source[y * _width + x - 1];
                    var v2 = source[y * _width + x + 1];
                    var v3 = source[(y - 1) * _width + x];
                    var v4 = source[(y + 1) * _width + x];

                    var v = ((v1 + v2 + v3 + v4) / 2.0f) - dest[index];
                    int iv = (int)v;

                    dest[index] = Math.Max(0, iv);
                    dest[index] = Math.Min(_maxForce, dest[index]);
                    dest[index] = (int)(dest[index] * _damping);
                }
            }
        }

        private void SwapBuffers()
        {
            _frontBuffer = _frontBuffer == _buffer1 ? _buffer2 : _buffer1;
            _backBuffer = _backBuffer == _buffer2 ? _buffer1 : _buffer2;
        }

        private void Render()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    int i = y * _width + x;
                    int value = _frontBuffer[i];
                    float unit = (float)value / _maxForce;
                    int colour = (int)(255.0f * unit);

                    RenderOutput.SetPixel(x, y, Color.FromArgb(colour, colour, colour));
                }
            }
        }

        public void AddSplash(int x, int y)
        {
            // Initial point.
            _buffer1[y * _width + x] = _initialForce;

            // Left/Right of point
            _buffer1[y * _width + x + 1] = _initialForce;
            _buffer1[y * _width + x - 1] = _initialForce;

            // Up/Down of point
            _buffer1[(y - 1) * _width + x] = _initialForce;
            _buffer1[(y + 1) * _width + x] = _initialForce;

            _buffer1[(y - 1) * _width + x - 1] = _initialForce;
            _buffer1[(y - 1) * _width + x + 1] = _initialForce;

            _buffer1[(y + 1) * _width + x - 1] = _initialForce;
            _buffer1[(y + 1) * _width + x + 1] = _initialForce;
        }
    }
}
