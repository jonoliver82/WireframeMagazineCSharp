// **********************************************************************************
// Filename					- KeyboardPyGame.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Core
{
    public abstract class KeyboardPyGame : PyGame
    {
        private Dictionary<Keys, bool> _keyboardState;

        protected KeyboardPyGame(int width, int height, ITimerFactory timerFactory)
            : base(width, height, timerFactory)
        {
            _keyboardState = new Dictionary<Keys, bool>
            {
                { Keys.Left, false },
                { Keys.Right, false },
                { Keys.Up, false },
                { Keys.Down, false },
                { Keys.W, false },
                { Keys.A, false },
                { Keys.S, false },
                { Keys.D, false },
                { Keys.R, false },
                { Keys.E, false },
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
