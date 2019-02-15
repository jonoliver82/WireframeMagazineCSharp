using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core
{
    public class KeyboardGame : IKeyboardGame
    {
        private Dictionary<Keys, bool> _keyboardState;

        public KeyboardGame()
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
