// **********************************************************************************
// Filename					- ContinueScreenState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Drawing;

namespace ContinuePyGame.States
{
    public class ContinueScreenState : BaseGameState
    {
        private int _frame = 0;

        public override void Draw(Graphics g)
        {
            g.DrawString("Continue Screen", _font, _brush, 200, 50);
            g.DrawString("Press [space] to play game", _font, _brush, 100, 80);

            // Display the time remaining until 10 seconds have passed
            g.DrawString($"{(10 - _frame) + 1}", _font, _brush, 50, 110);
        }
    }
}
