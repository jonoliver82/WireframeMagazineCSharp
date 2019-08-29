// **********************************************************************************
// Filename					- ContinueScreenState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System;
using System.Drawing;

namespace ContinuePyGame.States
{
    public class ContinueScreenState : BaseGameState
    {
        private TimeSpan _timeout = TimeSpan.FromSeconds(10);
        private TimeSpan _timeInState;

        public override void Draw(Graphics g)
        {
            g.DrawString("Continue Screen", Font, Brush, 200, 50);
            g.DrawString("Press [space] to play game", Font, Brush, 100, 80);

            // Display the time remaining until 10 seconds have passed
            g.DrawString($"{_timeout - _timeInState}", Font, Brush, 180, 110);
        }

        public override void Update(TimeSpan timeInState)
        {
            _timeInState = timeInState;
        }
    }
}
