using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Core
{
    public abstract class MousePyGame : PyGame
    {
        private bool _isMouseDown = false;

        protected bool IsMouseDown => _isMouseDown;

        public MousePyGame(int width, int height, ITimerFactory timerFactory)
            : base (width, height, timerFactory)
        {
        }

        public virtual void MouseDown(int x, int y)
        {
            _isMouseDown = true;
        }

        /// <summary>
        /// Derived classes to implement their own logic, probably using the IsMouseDown property
        /// to determine what action to take when the mouse is moved
        /// </summary>
        public abstract void MouseMove(int x, int y);

        public virtual void MouseUp(int x, int y)
        {
            _isMouseDown = false;
        }
    }
}
