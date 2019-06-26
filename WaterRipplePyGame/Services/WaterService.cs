// **********************************************************************************
// Filename					- WaterService.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;
using System.Drawing.Imaging;
using WaterRipplePyGame.Interfaces;
using WaterRipplePyGame.Options;

namespace WaterRipplePyGame.Services
{
    public class WaterService : IWaterService, IDisposable
    {
        private readonly WaterRippleOptions _options;

        private Bitmap _renderOutput;

        private int[] _buffer1;
        private int[] _buffer2;

        private int[] _frontBuffer;
        private int[] _backBuffer;

        private bool _disposedValue = false;

        public WaterService(WaterRippleOptions options)
        {
            _options = options;

            _buffer1 = new int[_options.Width * _options.Height];
            _buffer2 = new int[_options.Width * _options.Height];

            _frontBuffer = _buffer1;
            _backBuffer = _buffer2;

            _renderOutput = new Bitmap(_options.Width, _options.Height, PixelFormat.Format32bppArgb);
        }

        public Bitmap RenderOutput => _renderOutput;

        public void AddSplash(int x, int y)
        {
            // CA2233 potential overflow of y - check bounds before usage
            if (x >= 0 && x < _options.Width && y >= 0 && y < _options.Height)
            {
                // Initial point.
                _buffer1[(y * _options.Width) + x] = _options.InitialForce;

                // Left/Right of point
                _buffer1[(y * _options.Width) + x + 1] = _options.InitialForce;
                _buffer1[(y * _options.Width) + x - 1] = _options.InitialForce;

                // Up/Down of point
                _buffer1[((y - 1) * _options.Width) + x] = _options.InitialForce;
                _buffer1[((y + 1) * _options.Width) + x] = _options.InitialForce;

                _buffer1[((y - 1) * _options.Width) + x - 1] = _options.InitialForce;
                _buffer1[((y - 1) * _options.Width) + x + 1] = _options.InitialForce;

                _buffer1[((y + 1) * _options.Width) + x - 1] = _options.InitialForce;
                _buffer1[((y + 1) * _options.Width) + x + 1] = _options.InitialForce;
            }
        }

        public void Initialise(int width, int height)
        {
            _renderOutput = new Bitmap(width, height, PixelFormat.Format32bppArgb);
        }

        public void Update()
        {
            ProcessBuffers(_backBuffer, _frontBuffer);
            SwapBuffers();
            Render();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _renderOutput.Dispose();
                }

                _disposedValue = true;
            }
        }

        private void ProcessBuffers(int[] source, int[] dest)
        {
            // Start at 1, and end at size - 1 to skip edge elements
            for (int y = 1; y < _options.Height - 1; y++)
            {
                for (int x = 1; x < _options.Width - 1; x++)
                {
                    var index = (y * _options.Width) + x;

                    var v1 = source[(y * _options.Width) + x - 1];
                    var v2 = source[(y * _options.Width) + x + 1];
                    var v3 = source[((y - 1) * _options.Width) + x];
                    var v4 = source[((y + 1) * _options.Width) + x];

                    var v = ((v1 + v2 + v3 + v4) / 2.0f) - dest[index];
                    int iv = (int)v;

                    dest[index] = Math.Max(0, iv);
                    dest[index] = Math.Min(_options.MaxForce, dest[index]);
                    dest[index] = (int)(dest[index] * _options.Damping);
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
            for (int y = 0; y < _options.Height; y++)
            {
                for (int x = 0; x < _options.Width; x++)
                {
                    int i = (y * _options.Width) + x;
                    int value = _frontBuffer[i];
                    float unit = (float)value / _options.MaxForce;
                    int colour = (int)(255.0f * unit);

                    RenderOutput.SetPixel(x, y, Color.FromArgb(colour, colour, colour));
                }
            }
        }
    }
}
