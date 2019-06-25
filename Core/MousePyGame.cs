// **********************************************************************************
// Filename					- MousePyGame.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Interfaces;

namespace Core
{
    public abstract class MousePyGame : PyGame
    {
        private bool _isMouseDown = false;

        public MousePyGame(int width, int height, ITimerFactory timerFactory)
            : base(width, height, timerFactory)
        {
        }

        protected bool IsMouseDown => _isMouseDown;

        public virtual void MouseDown(int x, int y)
        {
            _isMouseDown = true;
        }

        /// <summary>
        /// Derived classes to implement their own logic, probably using the IsMouseDown property
        /// to determine what action to take when the mouse is moved.
        /// </summary>
        public abstract void MouseMove(int x, int y);

        public virtual void MouseUp(int x, int y)
        {
            _isMouseDown = false;
        }
    }
}
