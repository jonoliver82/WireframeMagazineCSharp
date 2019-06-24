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
    public abstract class KeyboardPyGame : PyGame
    {
        private Dictionary<Keys, bool> _keyboardState;

        public KeyboardPyGame(int width, int height, ITimerFactory timerFactory)
            : base (width, height, timerFactory)
        {
            _keyboardState = new Dictionary<Keys, bool>
            {
                { Keys.Left, false },
                { Keys.Right, false },
                { Keys.A, false },
                { Keys.D, false },
                { Keys.Space, false },
            };
        }

        public Dictionary<Keys, bool> KeyboardState => _keyboardState;

        public virtual void KeyDown(Keys keyCode)
        {
            _keyboardState[keyCode] = true;
        }

        public virtual void KeyUp(Keys keyCode)
        {
            _keyboardState[keyCode] = false;
        }
    }
}
