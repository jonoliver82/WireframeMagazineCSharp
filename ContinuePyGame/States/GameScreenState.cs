// **********************************************************************************
// Filename					- GameScreenState.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using ContinuePyGame.Interfaces;
using System;
using System.Drawing;

namespace ContinuePyGame.States
{
    public class GameScreenState : BaseGameState
    {
        public override void Draw(Graphics g)
        {
            g.DrawString("Game Screen", _font, _brush, 200, 50);
            g.DrawString("Press [e] to end game", _font, _brush, 100, 80);
        }
    }
}
