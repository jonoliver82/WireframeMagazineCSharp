// **********************************************************************************
// Filename					- WaterRipple.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core;
using Core.Interfaces;
using System;
using System.Drawing;
using WaterRipplePyGame.Interfaces;
using WaterRipplePyGame.Options;

namespace WaterRipplePyGame
{
    public class WaterRipple : MousePyGame
    {
        private readonly IRandom _random;
        private readonly IWaterService _waterService;
        private readonly WaterRippleOptions _options;

        public WaterRipple(ITimerFactory timerFactory,
            IRandom random,
            IWaterService waterService,
            WaterRippleOptions options)
            : base(options.Width, options.Height, timerFactory)
        {
            _random = random;
            _waterService = waterService;
            _options = options;

            ScheduleClockInterval(AddSplash, 1000);
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_waterService.RenderOutput, 0, 0);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            _waterService.Update();
        }

        public override void MouseMove(int x, int y)
        {
            if (IsMouseDown)
            {
                _waterService.AddSplash(x, y);
            }
        }

        public override void MouseDown(int x, int y)
        {
            base.MouseDown(x, y);
            _waterService.AddSplash(x, y);
        }

        public override void MouseUp(int x, int y)
        {
            base.MouseUp(x, y);
            _waterService.AddSplash(x, y);
        }

        private void AddSplash()
        {
            // select a random position on the screen
            var x = _random.Next(1, _options.Width - 1);
            var y = _random.Next(1, _options.Height - 1);

            // call the splash function for that position
            _waterService.AddSplash(x, y);
        }
    }
}
