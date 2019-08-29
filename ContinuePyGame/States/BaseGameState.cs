// **********************************************************************************
// Filename					- BaseGameState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ContinuePyGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ContinuePyGame.States
{
    public abstract class BaseGameState : IGameState
    {
        private static SolidBrush _brush = new SolidBrush(Color.White);
        private static Font _font = new Font(FontFamily.GenericMonospace, 20.0f);

        private Dictionary<IGameState, Func<bool>> _rules;

        protected BaseGameState()
        {
            _rules = new Dictionary<IGameState, Func<bool>>();
        }

        public Dictionary<IGameState, Func<bool>> Rules => _rules;

        protected SolidBrush Brush => _brush;

        protected Font Font => _font;

        public void AddTransitionRule(IGameState destinationState, Func<bool> predicate)
        {
            _rules[destinationState] = predicate;
        }

        // Derived classes must implement this method
        public abstract void Draw(Graphics g);

        public virtual void Update(TimeSpan timeInState)
        {
            // No action required in base class. Derived classes can override this method if necessary.
        }
     }
}
