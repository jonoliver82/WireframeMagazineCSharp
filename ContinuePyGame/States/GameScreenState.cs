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
            g.DrawString("Game Screen", Font, Brush, 200, 50);
            g.DrawString("Press [e] to end game", Font, Brush, 100, 80);
        }
    }
}
