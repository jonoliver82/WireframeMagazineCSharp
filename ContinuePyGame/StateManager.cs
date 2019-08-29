// **********************************************************************************
// Filename					- StateManager.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ContinuePyGame.Interfaces;
using System;
using System.Drawing;

namespace ContinuePyGame
{
    public class StateManager
    {
        private IGameState _currrent;
        private TimeSpan _timeInState;

        public StateManager(IGameState initialState)
        {
            _currrent = initialState;
            _timeInState = TimeSpan.Zero;
        }

        public double TimeInStateSeconds => _timeInState.TotalSeconds;

        public void Update(TimeSpan timeSinceLastUpdate)
        {
            _timeInState += timeSinceLastUpdate;

            // If any rule evaluates to true, then switch to that state and reset the timer
            foreach (var kvp in _currrent.Rules)
            {
                if (kvp.Value())
                {
                    _currrent = kvp.Key;
                    _timeInState = TimeSpan.Zero;
                    break;
                }
            }

            _currrent.Update(_timeInState);
        }

        public void Draw(Graphics g)
        {
            _currrent.Draw(g);
        }
    }
}
