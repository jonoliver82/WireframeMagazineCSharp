using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core
{
    public abstract class PyGame
    {
        private readonly ITimerFactory _timerFactory;

        public int Width { get; set; }

        public int Height { get; set; }

        private Timer _timer;

        public PyGame(int width, int height, ITimerFactory timerFactory)
        {
            Width = width;
            Height = height;

            _timerFactory = timerFactory;
        }

        public abstract void Draw(Graphics g);

        public abstract void Update(TimeSpan timeSinceLastUpdate, Graphics g);

        public void ScheduleClockInterval(Action action, int intervalMs)
        {
            _timer = _timerFactory.Create(action, intervalMs);
            _timer.Enabled = true;
        }
    }
}
