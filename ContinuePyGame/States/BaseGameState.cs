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
        protected static SolidBrush _brush = new SolidBrush(Color.White);
        protected static Font _font = new Font(FontFamily.GenericMonospace, 20.0f);

        protected Dictionary<IGameState, Func<bool>> _rules;

        protected BaseGameState()
        {
            _rules = new Dictionary<IGameState, Func<bool>>();
        }

        public void AddTransitionRule(IGameState destinationState, Func<bool> predicate)
        {
            _rules[destinationState] = predicate;
        }

        // Derived classes must implement this method
        public abstract void Draw(Graphics g);
     }
}
