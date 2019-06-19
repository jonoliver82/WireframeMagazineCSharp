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

        private Dictionary<Keys, bool> _keyboardState;

        public int Width { get; set; }

        public int Height { get; set; }

        private Timer _timer;

        public PyGame(int width, int height, ITimerFactory timerFactory)
        {
            Width = width;
            Height = height;

            _timerFactory = timerFactory;

            _keyboardState = new Dictionary<Keys, bool>
            {
                { Keys.Left, false },
                { Keys.Right, false },
                { Keys.A, false },
                { Keys.D, false },
                { Keys.Space, false },
            };
        }

        protected Dictionary<Keys, bool> KeyboardState => _keyboardState;

        public abstract void Draw(Graphics g);

        public abstract void Update(TimeSpan timeSinceLastUpdate, Graphics g);

        public void ScheduleClockInterval(Action action, int intervalMs)
        {
            _timer = _timerFactory.Create(action, intervalMs);
            _timer.Enabled = true;
        }

        public void KeyDown(KeyEventArgs e)
        {
            _keyboardState[e.KeyCode] = true;
        }

        public void KeyUp(KeyEventArgs e)
        {
            _keyboardState[e.KeyCode] = false;
        }
    }
}
