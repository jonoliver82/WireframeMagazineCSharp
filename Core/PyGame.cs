// **********************************************************************************
// Filename					- PyGame.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Core
{
    public abstract class PyGame
    {
        private readonly ITimerFactory _timerFactory;

        private Timer _timer;

        protected PyGame(int width, int height, ITimerFactory timerFactory)
        {
            Width = width;
            Height = height;

            _timerFactory = timerFactory;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public abstract void Draw(Graphics g);

        public abstract void Update(TimeSpan timeSinceLastUpdate, Graphics g);

        public void ScheduleClockInterval(Action action, int intervalMs)
        {
            _timer = _timerFactory.Create(action, intervalMs);
            _timer.Enabled = true;
        }
    }
}
